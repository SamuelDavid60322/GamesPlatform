using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Bson;
namespace GamesPlatform.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(ApplicationDbContext applicationDbContext, ShoppingCart shoppingCart)
        {
            _applicationDbContext = applicationDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(List<ShoppingCartItem> items, string firstName, string lastName, string addressLine1, string addressLine2, string zipCode, string city, string country, string phoneNumber, string email)
        {
            //order.OrderPlaced = DateTime.Now;
            //_applicationDbContext.Orders.Add(order);

            var order = new Order()
            {
                FirstName = firstName,
                LastName = lastName,
                AddressLine1 = addressLine1,
                AddressLine2 = addressLine2,
                ZipCode = zipCode,
                City = city,
                Country = country,
                PhoneNumber = phoneNumber,
                Email = email
                
                
            };
            _applicationDbContext.Orders.Add(order);
            _applicationDbContext.SaveChanges();

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {

                    Amount = item.Amount,
                    GameID = item.Game.GameID,
                    OrderID = order.OrderID,
                    Price = item.Game.Price,
                    
                };
                _applicationDbContext.OrderDetails.Add(orderDetail);
            }
            _applicationDbContext.SaveChanges();
        }

        public List<Order> GetOrdersByFirstName(string firstName)
        {
            var orders = _applicationDbContext.Orders.Include(n => n.OrderDetails).ThenInclude(n => n.Game).Where(n => n.FirstName == firstName).ToList();
            return orders;
        }

    }
}
