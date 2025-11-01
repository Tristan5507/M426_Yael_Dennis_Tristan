using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Currency;

namespace M426_Yael_Dennis_Tristan.Players
{
    public class HumanBlackJackPlayer : ABlackJackPlayer
    {
        private readonly IInputService _inputService;

        public HumanBlackJackPlayer(string name, IHand hand, PlayerType playerType, IBlackJackConsoleService consoleService, IInputService inputService, IJettonService jettonService, IBettingService bettingService) 
            : base(name, hand, playerType, consoleService, jettonService, bettingService)
        {
            _inputService = inputService;
        }

        public override string GetDecision()
        {
            return _inputService.GetHitOrStandDecision(this.Name);
        }
    }
}
