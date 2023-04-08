using System.ComponentModel.DataAnnotations;

namespace GamesPlatform.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set;}
    }
}
