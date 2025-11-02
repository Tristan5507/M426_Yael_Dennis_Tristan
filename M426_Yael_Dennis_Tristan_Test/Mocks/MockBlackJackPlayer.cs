using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockBlackJackPlayer : ABlackJackPlayer
    {
        private string decision;
        public MockBlackJackPlayer(string name, string decisicion, IHand hand, IPlayerTypeBehavior playerTypeBehavior, IBlackJackConsoleService consoleService) : base(name, hand, playerTypeBehavior, consoleService)
        {
            this.decision = decisicion;
        }

        public override string GetDecision()
        {
            return decision;
        }
    }
}
