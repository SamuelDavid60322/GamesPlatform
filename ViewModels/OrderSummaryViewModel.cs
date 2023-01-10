using GamesPlatform.Models;

namespace GamesPlatform.ViewModels
{
    public class OrderSummaryViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public Order Order { get; set; }
    }
}
