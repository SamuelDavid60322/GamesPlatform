namespace GamesPlatform.Models
{
    public class GamesModel
    {
        public string GameID { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        public double Price { get; set; }
        public string GameImageUrl { get; set; }
        public string GameImageThumbnailUrl { get; set; }
        public string IsFeaturedGame { get; set; }
        public string CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
