namespace GamesPlatform.Models
{
    public class Verification
    {
        public int VerificationID { get; set; }
        public string UserID { get; set; }
        public byte[] Content { get; set; }
        public string Status { get; set; }
        public DateTime DateOfRequest { get; set; }

    }
}
