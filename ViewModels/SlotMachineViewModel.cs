using GamesPlatform.Models;

namespace GamesPlatform.ViewModels
{
    public class SlotMachineViewModel
    {
        public string[] Reels { get; set; }
        public bool? IsWinner { get; set; }
        public decimal AmountWon { get; set; }
        public CasinoResult CasinoResult { get; set; }
    }
}
