using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockBlackJackPlayer : ABlackJackPlayer
    {
        public MockBlackJackPlayer(string name, IHand hand, IPlayerTypeBehavior playerTypeBehavior, IBlackJackConsoleService consoleService) : base(name, hand, playerTypeBehavior, consoleService)
        {
        }

        public override string GetDecision()
        {
            throw new NotImplementedException();
        }
    }
}
