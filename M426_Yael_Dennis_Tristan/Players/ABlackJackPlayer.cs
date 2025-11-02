using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.ConsoleService;

namespace M426_Yael_Dennis_Tristan.Players
{
    public abstract class ABlackJackPlayer : APlayer
    {
        private readonly IHand _hand;
        protected readonly IBlackJackConsoleService _consoleService;

        public ABlackJackPlayer(string name, IHand hand, IPlayerTypeBehavior playerTypeBehavior, IBlackJackConsoleService consoleService)
                                : base(name, playerTypeBehavior)
        {
            _hand = hand;
            _consoleService = consoleService;
        }

        public void AddCard(Card? card) => _hand.AddCard(card);
        public int GetHandValue() => _hand.GetValue();
        public void ClearHand() => _hand.Clear();
        public List<Card> GetCards() => _hand.GetCards();

        public abstract string GetDecision();
    }
}
