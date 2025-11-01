using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.Currency
{
    public interface IBettingService
    {
        public void GetBets(APlayer player, int betInput);
    }
}