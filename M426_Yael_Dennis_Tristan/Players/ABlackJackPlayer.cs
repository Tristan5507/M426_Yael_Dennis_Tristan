using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Currency;

namespace M426_Yael_Dennis_Tristan.Players
{
    public abstract class ABlackJackPlayer : APlayer
    {
        private readonly IHand _hand;
        protected readonly IBlackJackConsoleService _consoleService;

        public ABlackJackPlayer(string name, IHand hand, PlayerType playerType, IBlackJackConsoleService consoleService, 
                                IJettonService jettonService, IBettingService bettingService) 
                                : base(name, playerType, jettonService, bettingService)
        {
            _hand = hand;
            _consoleService = consoleService;
        }

        public void AddCard(Card? card) => _hand.AddCard(card);
        public int GetHandValue() => _hand.GetValue();
        public void ClearHand() => _hand.Clear();
        public void PlayTurn(IBlackJackDealer dealer)
        {
            _consoleService.RenderTurnHeader(this.Name);

            while (this.GetHandValue() < 21)
            {
                string choice = this.GetDecision();

                if (choice == "h")
                {
                    var card = dealer.DrawCard();
                    if (card != null)
                    {
                        this.AddCard(card);
                        _consoleService.RenderCardDraw(this.Name, card, this.GetHandValue());

                        if (this.GetHandValue() > 21)
                        {
                            _consoleService.RenderBust(this.Name);
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public abstract string GetDecision();

    }
}
