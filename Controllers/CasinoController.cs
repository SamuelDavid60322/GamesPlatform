using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using GamesPlatform.Repositories;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Security.Claims;

namespace GamesPlatform.Controllers
{
    public class CasinoController : Controller
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly ICasinoResultRepository _casinoResultRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IVerificationRepository _verificationRepository;

        public CasinoController(IGamesRepository gamesRepository, ICasinoResultRepository casinoResultRepository, IWalletRepository walletRepository, IVerificationRepository verificationRepository)
        {
            _gamesRepository = gamesRepository;
            _casinoResultRepository = casinoResultRepository;
            _walletRepository = walletRepository;
            _verificationRepository = verificationRepository;
        }
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var verification = _verificationRepository.RetrieveVerificationByUserID(userId);


                if (verification == null)
                {
                    return RedirectToAction("Index", "Verification");
                }
                else if (verification.Status == "Pending")
                {
                    ViewBag.VerificationMessage = "Your Verification request to play casino Games is being reviewed by admins, Check back later.";
                }
                else if (verification.Status == "Denied")
                {
                    ViewBag.VerificationMessage = "Sorry, but your request to play casino games has been denied. Email support if you think this a mistake.";
                }
            }


            var casinoViewModel = new CasinoViewModel
            {
                CasinoGame = _gamesRepository.CasinoGames
            };
            return View(casinoViewModel);
        }

    }
}
