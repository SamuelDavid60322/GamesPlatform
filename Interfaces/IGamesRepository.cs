using GamesPlatform.Models;

namespace GamesPlatform.Interfaces
{
    public interface IGamesRepository
    {
        IEnumerable<Games> Games { get; set;}
        IEnumerable<Games> FeaturedGames { get;}
        Games GetGamesById (int GamesId);
    }
}
