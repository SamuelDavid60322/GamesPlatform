using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;

namespace GamesPlatform.Repositories
{
    public class VerificationRepository : IVerificationRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public VerificationRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void CreateVerification(Verification verification)
        {
            verification.DateOfRequest = DateTime.Now;
            _applicationDbContext.Verifications.Add(verification);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<Verification> RetrieveAllVerifications()
        {
            var result = (from v in _applicationDbContext.Verifications
                          select v).ToList();
            return result;
        }

        public Verification RetrieveVerificationByID(int verificationId)
        {
            _applicationDbContext.Verifications.FirstOrDefault(w => w.VerificationID == verificationId);
            var result = _applicationDbContext.Verifications.FirstOrDefault(w => w.VerificationID == verificationId);
            return result;
        }

        public Verification RetrieveVerificationByUserID(string userId)
        {
            var result = _applicationDbContext.Verifications.FirstOrDefault(w => w.UserID == userId);
            return result;
        }

        public void UpdateVerification(int verificationId, string status)
        {
            _applicationDbContext.Verifications.FirstOrDefault(w => w.VerificationID == verificationId);
            var result = _applicationDbContext.Verifications.FirstOrDefault(w => w.VerificationID == verificationId);

            result.Status = status;

            _applicationDbContext.SaveChanges();
        }
    }
}
