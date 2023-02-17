using System.ComponentModel.DataAnnotations;

namespace GamesPlatform.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
        [Range(0.00, 900.00)]
        public decimal Price { get; set; }
        public string GameImageUrl { get; set; }
        public string GameImageThumbnailUrl { get; set; }
        public bool IsFeaturedGame { get; set; }
        public bool IsFreeGame { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
