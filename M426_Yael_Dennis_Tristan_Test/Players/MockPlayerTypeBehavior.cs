using M426_Yael_Dennis_Tristan;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Players
{
public class MockPlayerTypeBehavior : IPlayerTypeBehavior
{
    public int BetToReturn { get; set; } = 50;
    public bool BalanceChangedCalled { get; private set; }

    public int GetBet(APlayer player) => BetToReturn;

    public void OnBalanceChanged(APlayer player, List<IJetonObserver> observers)
    {
        BalanceChangedCalled = true;

        foreach (var obs in observers)
        {
            obs.Notify(player);
        }
    }
}
}