using GamesPlatform.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamesPlatform.Controllers
{
    public class PlayGameController : Controller
    {
        private readonly IWalletRepository _walletRepository;
        public PlayGameController(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public IActionResult PlayGame(string gameID)
        {
            ViewBag.GameID = gameID;
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult SubtractFromWalletAndPlayGame(string gameID)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            decimal amountToSubtract = 5.00M;

            _walletRepository.SubtractFromWallet(userId, amountToSubtract);
            return RedirectToAction("PlayGame", new { GameID = gameID });
        }
    }
}
