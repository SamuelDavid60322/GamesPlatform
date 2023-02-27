using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GamesPlatform.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
