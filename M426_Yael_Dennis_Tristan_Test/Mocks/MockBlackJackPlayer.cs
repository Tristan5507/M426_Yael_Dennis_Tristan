using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockBlackJackPlayer : ABlackJackPlayer
    {
        public bool ClearHandWurdeAufgerufen { get; private set; }
        private Queue<string> _decisions = new Queue<string>();

        public MockBlackJackPlayer(string name, MockHand hand, IPlayerTypeBehavior playerTypeBehavior, IBlackJackConsoleService consoleService)
            : base(name, hand, playerTypeBehavior, consoleService)
        {
        }

        public void SetzeDecisions(params string[] decisions)
        {
            _decisions = new Queue<string>(decisions);
        }

        public override string GetDecision()
        {
            if (_decisions.Count > 0)
            {
                return _decisions.Dequeue();
            }
            return "s";
        }
    }
}
