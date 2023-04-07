using GamesPlatform.Models;

namespace GamesPlatform.ViewModels
{
    public class BlackJackViewModel
    {
        public List<int> PlayerHand { get; set; }
        public List<int> DealerHand { get; set; }
        public bool? IsWinner { get; set; }
        public decimal AmountWon { get; set; }
        public CasinoResult CasinoResult { get; set; }
    }
}
