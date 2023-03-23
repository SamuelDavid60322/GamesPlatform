using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Security.Claims;

namespace GamesPlatform.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart, UserManager<IdentityUser> userManager)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _userManager = userManager;
           
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
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                string firstName = "";
                string lastName = "";
                string addressLine1 = "";
                string addressLine2 = "";
                string zipCode = "";
                string city = "";
                string country = "";
                string phoneNumber = "";
                string email = User.FindFirstValue(ClaimTypes.NameIdentifier);
                int orderId = 0;
                order.OrderID = orderId;

                //var orderDetails = _orderDetailRepository.GetAllOrderDetails(orderId);
                _orderRepository.CreateOrder(items, userId, firstName, lastName, addressLine1, addressLine2, zipCode, city, country, phoneNumber, email);

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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var orders = _orderRepository.GetOrdersByUserID(userId);
            return View(orders);

        }
    }
}
