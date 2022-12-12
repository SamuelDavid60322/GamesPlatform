using GamesPlatform.Models;

namespace GamesPlatform.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
