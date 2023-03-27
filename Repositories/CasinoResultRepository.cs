using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;

namespace GamesPlatform.Repositories
{
    public class CasinoResultRepository : ICasinoResultRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CasinoResultRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void CreateCasinoResult(CasinoResult gameResult)
        {

            gameResult.DateResultPlaced = DateTime.Now;
            _applicationDbContext.Add(gameResult);
            _applicationDbContext.SaveChanges();
        }
    }
}
