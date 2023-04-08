using PayoutsSdk.Payouts;
using System.ComponentModel.DataAnnotations;

namespace GamesPlatform.Models
{
    public class FileUpload
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile file { get; set; }
    }
}
