using GamesPlatform.Models;
using Microsoft.AspNetCore.Http.Features;

namespace GamesPlatform.Interfaces
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetAllOrderDetails(int orderID);
        OrderDetail GetOrderDetailById(int orderDetailID);
    }
}
