using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GamesPlatform.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(IGamesRepository gamesRepository, ShoppingCart shoppingCart) 
        {
            _gamesRepository= gamesRepository;
            _shoppingCart= shoppingCart;
        }
        
        public ViewResult Index()
        {
            var items= _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(sCVM);
        }
        public RedirectToActionResult AddToShoppingCart(int gameID)
        {
            var selectedGame = _gamesRepository.Games.FirstOrDefault(p => p.GameID == gameID);
            if(selectedGame != null)
            {
                _shoppingCart.AddToCart(selectedGame, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int gameID)
        {
            var selectedGame = _gamesRepository.Games.FirstOrDefault(p => p.GameID == gameID);
            if (selectedGame != null)
            {
                _shoppingCart.RemoveFromCart(selectedGame);
            }
            return RedirectToAction("Index");
        }

    }
}
