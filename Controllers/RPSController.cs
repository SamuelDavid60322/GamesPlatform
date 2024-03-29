﻿using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamesPlatform.Controllers
{
    [Authorize]
    public class RPSController : Controller
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly ICasinoResultRepository _casinoResultRepository;
        private readonly IWalletRepository _walletRepository;

        public RPSController(IGamesRepository gamesRepository, ICasinoResultRepository casinoResultRepository, IWalletRepository walletRepository)
        {
            _gamesRepository = gamesRepository;
            _casinoResultRepository = casinoResultRepository;
            _walletRepository = walletRepository;
        }
        [Authorize]
        public IActionResult RPSIndex()
        {
            return RedirectToAction("Play", "RPS");
        }

        [Authorize]
        public IActionResult Play(string userChoice)
        {
            if (userChoice == null)
            {
                return View("RPSIndex");
            }

            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var computerChoice = GetComputerChoice();
            var (result, amountWon) = DetermineResult(userChoice, computerChoice);
            var win = result == "Congratulations! You won!";

            var gameResult = new CasinoResult
            {
                UserChoice = userChoice,
                ComputerChoice = computerChoice,
                Result = result,
                Win = win,
                AmountWon = amountWon,
                DateResultPlaced = DateTime.UtcNow
            };
            _casinoResultRepository.CreateCasinoResult(gameResult);
            if (gameResult.Win)
            {
                _walletRepository.AddToWallet(userId, gameResult.AmountWon);
            }
            return View("RPSIndex", gameResult);
        }

        private string GetComputerChoice()
        {
            var random = new Random();
            int choice = random.Next(1, 4);

            return choice switch
            {
                1 => "Rock",
                2 => "Paper",
                _ => "Scissors"
            };
        }

        private (string, decimal) DetermineResult(string userChoice, string computerChoice)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userChoice == computerChoice) return ("It's a tie!", 0);
            if (userChoice == "Rock" && computerChoice == "Scissors") return ("Congratulations! You won!", 10);
            if (userChoice == "Paper" && computerChoice == "Rock") return ("Congratulations! You won!", 10);
            if (userChoice == "Scissors" && computerChoice == "Paper") return ("Congratulations! You won!", 10);
            return ("Sorry, you lost!", 0);
        }
    }
}
