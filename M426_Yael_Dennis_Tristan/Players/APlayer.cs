using M426_Yael_Dennis_Tristan.Currency;

namespace M426_Yael_Dennis_Tristan.Players
{
    public abstract class APlayer
    {
        public string Name { get; }
        public PlayerType PlayerType { get; }
        public int CurrentBet { get; set; }
        private readonly IJettonService _jettonService;
        private readonly IBettingService _bettingService;

        protected APlayer(string name, PlayerType playerType, IJettonService jettonService, IBettingService bettingService)
        {
            Name = name;
            PlayerType = playerType;
            _jettonService = jettonService;
            _bettingService = bettingService;
        }

        public int GetJettonBalance() => _jettonService.Balance;

        public void GetBets(APlayer player, int betInput)
        {
            _bettingService.GetBets(player, betInput);
        }

        public void PlaceBet()
        {
            _jettonService.PlaceBet(CurrentBet);
        }

        public void Win()
        {
            _jettonService.AddWinnings(CurrentBet * 2);
            CurrentBet = 0;
        }

        public void Lose()
        {
            CurrentBet = 0;
        }
    }
}