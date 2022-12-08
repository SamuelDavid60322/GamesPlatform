namespace GamesPlatform.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public  List<Game> Games { get; set; }
    }
}
