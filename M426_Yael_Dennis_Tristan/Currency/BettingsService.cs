using M426_Yael_Dennis_Tristan.Players;
using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan.Currency
{
    public class BettingService : IBettingService
    {
        private readonly IRandom _random;

        public BettingService(IRandom random)
        {
            _random = random;
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