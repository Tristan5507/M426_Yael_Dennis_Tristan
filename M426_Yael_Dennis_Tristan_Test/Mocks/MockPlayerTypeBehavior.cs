using M426_Yael_Dennis_Tristan;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockPlayerTypeBehavior : IPlayerTypeBehavior
    {
        public int GetBet(APlayer player)
        {
            return 0;
        }

        public void OnBalanceChanged(APlayer player, List<IJetonObserver> observers)
        {
            
        }
    }
}
