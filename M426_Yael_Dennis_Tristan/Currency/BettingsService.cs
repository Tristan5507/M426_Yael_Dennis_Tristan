using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Currency;
using M426_Yael_Dennis_Tristan.Players;
using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan.Currency
{
    public class BettingService : IBettingService
    {
        private readonly IRandom _random;
        private readonly IJettonService _jettonService;

        public BettingService(IRandom random, IJettonService jettonService)
        {
            _random = random;
            _jettonService = jettonService;
        }

        public void GetBets(APlayer player, int betInput)
        {
            if (player.PlayerType == PlayerType.Human)
            {
                player.CurrentBet = betInput;
            }
            else
            {
                player.CurrentBet = _random.Next(10, Math.Max(20, player.GetJettonBalance() / 5));
            }
        }
    }
}