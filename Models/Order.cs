using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Numerics;

namespace GamesPlatform.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        [Display(Name = "FirstName")]
        [StringLength(50)]
        [Required(ErrorMessage ="Please enter your First Name please!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name please!")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your Address")]
        [Display(Name = "Address")]
        [StringLength(100)]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage = "Please enter your Address 2 please!")]
        [Display(Name = "Address2")]
        [StringLength(100)]
        public string AddressLine2 { get; set;}

        [Required(ErrorMessage = "Please enter your ZipCode please!")]
        [Display(Name = "ZipCode")]
        [StringLength(20)]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please enter your City please!")]
        [Display(Name = "City")]
        [StringLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter your Country please!")]
        [Display(Name = "Country")]
        [StringLength(50)]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter your PhoneNumber please!")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "PhoneNumber")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter your Email please!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
        ErrorMessage = "The email address is not entered in a correct format")]
        [StringLength(50)]
        public string Email { get; set; }

        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
