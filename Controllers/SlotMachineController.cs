using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using GamesPlatform.Repositories;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GamesPlatform.Controllers
{
    [Authorize]
    public class SlotMachineController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IWalletRepository _walletRepository;

        public SlotMachineController(ApplicationDbContext applicationDbContext, IWalletRepository walletRepository)
        {
            _applicationDbContext = applicationDbContext;
            _walletRepository = walletRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Spin(SlotMachineViewModel model)
        {
            var rand = new Random();
            string[] symbols = { "A", "B", "C", "7" }; // Add or modify the symbols as desired

            model.Reels = new string[3];
            for (int i = 0; i < 3; i++)
            {
                model.Reels[i] = symbols[rand.Next(symbols.Length)];
            }

            model.IsWinner = model.Reels[0] == model.Reels[1] && model.Reels[1] == model.Reels[2];
            model.AmountWon = model.IsWinner.Value ? 10 : 0; // Change this to the desired win amount

            var casinoResult = new CasinoResult
            {
                UserChoice = string.Join(",", model.Reels),
                ComputerChoice = string.Join(",", model.Reels),
                Result = model.IsWinner.Value ? "Win" : "Lose",
                Win = model.IsWinner.Value,
                AmountWon = model.AmountWon,
                DateResultPlaced = DateTime.Now
            };

            _applicationDbContext.CasinoResults.Add(casinoResult);
            await _applicationDbContext.SaveChangesAsync();

            if (model.IsWinner.Value)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _walletRepository.AddToWallet(userId, model.AmountWon);
            }

            model.CasinoResult = casinoResult;

            return View("Index", model);
        }
    }
}
