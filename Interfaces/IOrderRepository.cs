using GamesPlatform.Models;
using Microsoft.AspNetCore.Http.Features;

namespace GamesPlatform.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(List<ShoppingCartItem> items, string userId, string firstName, string lastName, string addressLine1, string addressLine2, string zipCode, string city, string country, string phoneNumber, string email);
        List<Order> GetOrdersByUserID(string userId);

    }
}
