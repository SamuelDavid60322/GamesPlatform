namespace GamesPlatform.Models
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int GameID { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Game Game { get; set; }
        public Order Order { get; set; }
    }
}
