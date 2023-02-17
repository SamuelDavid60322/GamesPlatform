using GamesPlatform.Models;

namespace GamesPlatform.Interfaces
{
    public interface IGamesRepository
    {
        IEnumerable<Game> Games { get;}
        IEnumerable<Game> FeaturedGames { get;}
        IEnumerable<Game> FreeGames { get; }
        Game GetGamesById (int GamesId);
    }
}
