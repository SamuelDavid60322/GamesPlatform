using GamesPlatform.Models;

namespace GamesPlatform.Interfaces
{
    public interface IGamesRepository
    {
        IEnumerable<Game> Games { get;}
        IEnumerable<Game> FeaturedGames { get;}
        Game GetGamesById (int GamesId);
    }
}
