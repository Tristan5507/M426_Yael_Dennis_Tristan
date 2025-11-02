using M426_Yael_Dennis_Tristan;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockPlayerTypeBehavior : IPlayerTypeBehavior
    {
        public int GetBet(APlayer player)
        {
            throw new NotImplementedException();
        }

        public void OnBalanceChanged(APlayer player, List<IJetonObserver> observers)
        {
            throw new NotImplementedException();
        }
    }
}
