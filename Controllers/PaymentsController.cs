using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using GamesPlatform.Repositories;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace GamesPlatform.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;
        public PaymentsController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            StripeConfiguration.ApiKey = "sk_test_51MLfkELqDZptVo03ItEDQzIaHydvHEVvyIw7SV0Z0GmzqsDWyxV3lEWLkHzfnr4nrnxxInRobfod8LpmiLdlBqSw00oEP5ziP9";
        }

        [HttpPost("create-checkout-session")]
        public ActionResult CreateCheckoutSession()
        {
             decimal orderTotal;
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            orderTotal = _shoppingCart.GetShoppingCartTotal() * 100;

            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
        {
          new SessionLineItemOptions
          {
            PriceData = new SessionLineItemPriceDataOptions
            {
              UnitAmount = 2000,
              Currency = "eur",
              ProductData = new SessionLineItemPriceDataProductDataOptions
              {
                Name = "Total Amount",
              },
            },
            Quantity = 1,
          },
        },
                Mode = "payment",
                SuccessUrl = "https://localhost:7290/Payments/Success",
                CancelUrl = "https://localhost:7290/Payments/Cancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }
    }
}
