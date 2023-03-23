using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using GamesPlatform.Repositories;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GamesPlatform.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ApplicationDbContext _applicationDbContext;
        public LibraryController(IOrderRepository orderRepository, IGamesRepository gamesRepository, ApplicationDbContext applicationDbContext) 
        {
            _orderRepository = orderRepository;
            _gamesRepository = gamesRepository;
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Index()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var orders = _applicationDbContext.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Game).Where(o => o.UserID== userId).ToList();

                 var purchasedGames = orders.SelectMany(o => o.OrderDetails).Select(od => od.Game).Distinct().ToList();

            var viewModel = new LibraryViewModel
            {
                PurchasedGames = purchasedGames
            };
            return View(viewModel);
        }
    }
}
