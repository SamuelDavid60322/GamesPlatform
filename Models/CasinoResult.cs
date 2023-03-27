using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace GamesPlatform.Models
{
    public class CasinoResult
    {
            [Key]        
            [BindNever]
            public int ResultID { get; set; }
            public string UserChoice { get; set; }
            public string ComputerChoice { get; set; }
            public string Result { get; set; }
            public bool Win { get; set; }
            public decimal AmountWon { get; set; }
            public DateTime DateResultPlaced { get; set; }
        
    }
}
