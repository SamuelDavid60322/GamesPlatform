using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesPlatform.Controllers
{
    public class CasinoController : Controller
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly ICasinoResultRepository _casinoResultRepository;

        public CasinoController(IGamesRepository gamesRepository, ICasinoResultRepository casinoResultRepository)
        {
            _gamesRepository = gamesRepository;
            _casinoResultRepository = casinoResultRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("Play", "Casino");
        }

        [Authorize]
        public IActionResult Play(string userChoice)
        {
            if (userChoice == null)
            {
                return View("Index");
            }

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

            return View("Index", gameResult);
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
            if (userChoice == computerChoice) return ("It's a tie!", 0);
            if (userChoice == "Rock" && computerChoice == "Scissors") return ("Congratulations! You won!", 10);
            if (userChoice == "Paper" && computerChoice == "Rock") return ("Congratulations! You won!", 10);
            if (userChoice == "Scissors" && computerChoice == "Paper") return ("Congratulations! You won!", 10);
            return ("Sorry, you lost!", 0);
        }
    }
}
