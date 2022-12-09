namespace GamesPlatform.Models
{
    public class ShoppingCartItem
    {
        
        public int  ShoppingCartItemID { get; set; }
        public Game Game { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartID { get; set; }

    }
}
