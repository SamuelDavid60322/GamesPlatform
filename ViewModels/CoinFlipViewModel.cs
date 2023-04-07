using GamesPlatform.Models;

namespace GamesPlatform.ViewModels
{
    public class CoinFlipViewModel
    {
        public string PlayerChoice { get; set; }
        public string Result { get; set; }
        public bool? IsWinner { get; set; }
        public CasinoResult CasinoResult { get; set; }
    }
}
