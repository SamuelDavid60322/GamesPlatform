using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace GamesPlatform.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if(_shoppingCart.ShoppingCartItems.Count ==0)
            {
                ModelState.AddModelError("", "Cart is Empty");
            }

            if(ModelState.IsValid)
            {
                
                string firstName = "";
                string lastName = "";
                string addressLine1 = "";
                string addressLine2 = "";
                string zipCode = "";
                string city = "";
                string country = "";
                string phoneNumber = "";
                string email = "";
                int orderId = 0;

                _orderRepository.CreateOrder(items, firstName, lastName, addressLine1, addressLine2, zipCode, city, country, phoneNumber, email);
                _shoppingCart.ClearCart();
                return RedirectToAction("Index", "Payment");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return View("~/Views/Payment/Success");
        }

        public IActionResult Index()
        {
            string firstName = "";
            var orders = _orderRepository.GetOrdersByFirstName(firstName);
            return View(orders);

        }
    }
}
