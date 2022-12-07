namespace GamesPlatform.Models
{
    public class CategoryModel
    {
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public  List<GamesModel> Games { get; set; }
    }
}
