using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using GamesPlatform.Repositories;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GamesPlatform.Controllers
{
    public class CoinFlipController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IWalletRepository _walletRepository;
        public CoinFlipController(ApplicationDbContext applicationDbContext, IWalletRepository walletRepository)
        {
            _applicationDbContext = applicationDbContext;
            _walletRepository = walletRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Flip(CoinFlipViewModel model)
        {
            var rand = new Random();
            int outcome = rand.Next(2);
            string coinSide = outcome == 0 ? "Heads" : "Tails";

            model.Result = coinSide;
            model.IsWinner = coinSide.Equals(model.PlayerChoice, StringComparison.OrdinalIgnoreCase);

            var casinoResult = new CasinoResult
            {
                UserChoice = model.PlayerChoice,
                ComputerChoice = coinSide,
                Result = model.IsWinner.Value ? "Win" : "Lose",
                Win = model.IsWinner.Value,
                AmountWon = model.IsWinner.Value ? 5 : 0, // Change this to the desired win amount
                DateResultPlaced = DateTime.Now
            };

            _applicationDbContext.CasinoResults.Add(casinoResult);
            await _applicationDbContext.SaveChangesAsync();

            if (model.IsWinner.Value)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _walletRepository.AddToWallet(userId, casinoResult.AmountWon);
            }

            model.CasinoResult = casinoResult;

            return View("Index", model);
        }
    }
}
