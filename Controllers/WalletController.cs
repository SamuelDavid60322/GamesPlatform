using GamesPlatform.Interfaces;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace GamesPlatform.Controllers
{
    [Authorize]
    public class WalletController : Controller
    {
        private readonly IWalletRepository _walletRepository;
        public WalletController(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public ViewResult Index()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            decimal balance = _walletRepository.GetBalance(userId);

            var walletViewModel = new WalletViewModel
            {
                Balance = balance
            };

            return View(walletViewModel);
        }
    }
}
