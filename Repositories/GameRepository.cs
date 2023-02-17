using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesPlatform.Repositories
{
    public class GameRepository : IGamesRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GameRepository(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Game> Games => _applicationDbContext.Games.Include(c => c.Category);

        public IEnumerable<Game> FeaturedGames => _applicationDbContext.Games.Where(p => p.IsFeaturedGame).Include(c => c.Category);

        public IEnumerable<Game> FreeGames => _applicationDbContext.Games.Where(p => p.IsFreeGame).Include(c => c.Category);

        public Game GetGamesById(int GamesId) => _applicationDbContext.Games.FirstOrDefault(p => p.GameID == GamesId);
        
    }
}
