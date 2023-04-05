using GamesPlatform.Models;

namespace GamesPlatform.Interfaces
{
    public interface IWithdrawRepository
    {
        void WithdrawMade(Withdraw withdraw);
    }
}
