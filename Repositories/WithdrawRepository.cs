using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;

namespace GamesPlatform.Repositories
{
    public class WithdrawRepository : IWithdrawRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public WithdrawRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void WithdrawMade(Withdraw withdraw)
        {
            withdraw.WithdrawDate = DateTime.Now;

            _applicationDbContext.Withdraws.Add(withdraw);

            _applicationDbContext.SaveChanges();
        }
    }
}
