using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace GamesPlatform.Models
{
    public class Withdraw
    {
        [BindNever]
        public int WithdrawID { get; set; }
        public int WalletID { get; set; }

        [Required(ErrorMessage = "Please enter in the amount you want to transfer between 5-500")]
        [Display(Name = "Transfer Amount")]
        [DataType(DataType.Currency)]
        [Range(5, 500)]
        public decimal AmountTransfered { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "PayPal Email")]
        [EmailAddress]
        public string PayPalEmail { get; set; }
        public string PayPalBatchID { get; set; }
        public DateTime WithdrawDate { get; set; }
    }
}
