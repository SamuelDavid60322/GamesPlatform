using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;

namespace GamesPlatform.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public WalletRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void AddToWallet(string userId, decimal addedAmount)
        {
            var wallet = _applicationDbContext.Wallets.FirstOrDefault(w => w.UserID == userId);

            // If the wallet is not found, create a new wallet for the user
            if (wallet == null)
            {
                Wallet newWallet = new Wallet();
                newWallet.UserID = userId;
                newWallet.WalletBalance = 0.00M;
                _applicationDbContext.Wallets.Add(newWallet);
                decimal resultWon = newWallet.WalletBalance + addedAmount;
                newWallet.WalletBalance = resultWon;
                _applicationDbContext.SaveChanges();
            }
            else
            {
                decimal result = wallet.WalletBalance += addedAmount;
                wallet.WalletBalance = result;
                _applicationDbContext.SaveChanges();
            }
            
        }

        public decimal GetBalance(string userId)
        {
            var wallet = _applicationDbContext.Wallets.FirstOrDefault(w => w.UserID == userId);
            if(wallet == null )
            {
                return 0.00M;
            }
            decimal result = wallet.WalletBalance;
            return result;
        }

        public int RetrieveWalletID(string userId)
        {
            Wallet wallet = _applicationDbContext.Wallets.FirstOrDefault(w => w.UserID == userId);

            if (wallet == null)
            {
                return 0;
            }
            int result = wallet.WalletID;
            return result;
        }

        public void SubtractFromWallet(string userId, decimal removedAmount)
        {
            var wallet = _applicationDbContext.Wallets.FirstOrDefault(w => w.UserID == userId);

            decimal result = wallet.WalletBalance - removedAmount;
            wallet.WalletBalance = result;
            _applicationDbContext.SaveChanges();
        }

        public void AddFundsToWallet(string userId, decimal addedAmount)
        {
            var wallet = _applicationDbContext.Wallets.FirstOrDefault(w => w.UserID == userId);

            if (wallet == null)
            {
                Wallet newWallet = new Wallet();
                newWallet.UserID = userId;
                newWallet.WalletBalance = addedAmount;
                _applicationDbContext.Wallets.Add(newWallet);
            }
            else
            {
                wallet.WalletBalance += addedAmount;
            }

            _applicationDbContext.SaveChanges();
        }
    }
}

