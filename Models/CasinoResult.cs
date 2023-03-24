using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GamesPlatform.Models
{
    public class CasinoResult
    {
            [BindNever]
            public int ResultId { get; set; }
            public string UserChoice { get; set; }
            public string ComputerChoice { get; set; }
            public string Result { get; set; }
            public bool Win { get; set; }
            public decimal AmountWon { get; set; }
            public DateTime DateResultPlaced { get; set; }
        
    }
}
