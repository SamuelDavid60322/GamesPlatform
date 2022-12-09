using GamesPlatform.Models;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace GamesPlatform.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;

        }
        public IViewComponentResult Invoke()
        {
            var items = new List<ShoppingCartItem>() { new ShoppingCartItem(), new ShoppingCartItem() }; //_shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }
    }
}
