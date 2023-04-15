using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace GamesPlatform.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IGamesRepository _gamesRepository;
        private readonly ApplicationDbContext _applicationDbContext;


        public HomeController(IGamesRepository gamesRepository, ApplicationDbContext applicationDbContext)
        {
            _gamesRepository = gamesRepository;
            _applicationDbContext = applicationDbContext;
        }

        public ViewResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var purchasedGameIDs = new List<int>();
            if (userId != null)
            {
                purchasedGameIDs = _applicationDbContext.OrderDetails
                    .Include(od => od.Order)
                    .Where(od => od.Order.UserID == userId)
                    .Select(od => od.GameID)
                    .ToList();
            }

            var homeViewModel = new HomeViewModel
            {
                FeaturedGames = _gamesRepository.FeaturedGames,
                FreeGames = _gamesRepository.FreeGames,
                PurchasedGameIDs = purchasedGameIDs
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Libary()
        {
            return View();
        }

        public IActionResult Error404(int? statusCode = null)
        {
            if (statusCode.HasValue && statusCode.Value == 404)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}