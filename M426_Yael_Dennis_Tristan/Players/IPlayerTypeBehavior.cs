namespace M426_Yael_Dennis_Tristan.Players
{
    public interface IPlayerTypeBehavior
    {
        int GetBet(APlayer player);
        void OnBalanceChanged(APlayer player, List<IJetonObserver> observers);
    }
}
