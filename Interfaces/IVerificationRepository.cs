using GamesPlatform.Models;

namespace GamesPlatform.Interfaces
{
    public interface IVerificationRepository
    {
        void CreateVerification(Verification verification);
        void UpdateVerification(int verificationId, string status);
        IEnumerable<Verification> RetrieveAllVerifications();
        Verification RetrieveVerificationByID(int verificationId);
        Verification RetrieveVerificationByUserID(string userId);
    }
}
