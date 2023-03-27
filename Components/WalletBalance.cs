using GamesPlatform.Interfaces;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace GamesPlatform.Components
{
    public class WalletBalance : ViewComponent
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public WalletBalance(IWalletRepository walletRepository, IHttpContextAccessor httpContextAccessor)
        {
            _walletRepository = walletRepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public IViewComponentResult Invoke()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            decimal balance = _walletRepository.GetBalance(userId);
            var walletViewModel = new WalletViewModel
            {
                Balance = balance,
            };
            return View(walletViewModel);
        }
    }
}
