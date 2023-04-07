using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GamesPlatform.Controllers
{
    public class BlackJackController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IWalletRepository _walletRepository;

        public BlackJackController(ApplicationDbContext applicationDbContext, IWalletRepository walletRepository)
        {
            _applicationDbContext = applicationDbContext;
            _walletRepository = walletRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Play(BlackJackViewModel model)
        {
            model.PlayerHand = DrawCards(2);
            model.DealerHand = DrawCards(2);

            int playerScore = CalculateHandScore(model.PlayerHand);
            int dealerScore = CalculateHandScore(model.DealerHand);

            if (playerScore > 21)
            {
                model.IsWinner = false;
            }
            else if (dealerScore > 21 || playerScore > dealerScore)
            {
                model.IsWinner = true;
            }
            else
            {
                model.IsWinner = false;
            }

            model.AmountWon = model.IsWinner.Value ? 10 : 0; // Change this to the desired win amount

            var casinoResult = new CasinoResult
            {
                UserChoice = $"Player: {string.Join(",", model.PlayerHand)}; Dealer: {string.Join(",", model.DealerHand)}",
                ComputerChoice = $"Player: {string.Join(",", model.PlayerHand)}; Dealer: {string.Join(",", model.DealerHand)}",
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

        private List<int> DrawCards(int count)
        {
            var cards = new List<int>();
            var rand = new Random();
            for (int i = 0; i < count; i++)
            {
                cards.Add(rand.Next(1, 11));
            }
            return cards;
        }

        private int CalculateHandScore(List<int> hand)
        {
            int score = 0;
            foreach (int card in hand)
            {
                score += card;
            }
            return score;
        }
    }
}
