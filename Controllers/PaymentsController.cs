﻿using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using GamesPlatform.Repositories;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

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
        public IActionResult CreateCheckoutSession()
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
              UnitAmount = (long?)orderTotal,
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

        [Authorize]
        public IActionResult Success()
        {
            var items = _shoppingCart.GetShoppingCartItems();
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

            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }

        public IActionResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            var orderSummaryViewModel = new OrderSummaryViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };

            return View(orderSummaryViewModel);
        }
    }
}
