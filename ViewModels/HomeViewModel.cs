using GamesPlatform.Models;

namespace GamesPlatform.ViewModels
{
    public class HomeViewModel
    {public IEnumerable<Game> FeaturedGames { get; set; }
        public IEnumerable<Game> FreeGames { get; set; }
    }
}
