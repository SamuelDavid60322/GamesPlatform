namespace GamesPlatform.Interfaces
{
    public interface IWalletRepository
    {
        void AddToWallet(string userId, decimal addedAmount);
        void SubtractFromWallet(string userId, decimal removedAmount);
        decimal GetBalance(string userId);
        int RetrieveWalletID(string userId);
        void AddFundsToWallet(string userId, decimal amount);
    }
}
