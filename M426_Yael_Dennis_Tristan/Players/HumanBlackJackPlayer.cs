using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.ConsoleService;

namespace M426_Yael_Dennis_Tristan.Players
{
    public class HumanBlackJackPlayer : ABlackJackPlayer
    {
        private readonly IInputService _inputService;

        public HumanBlackJackPlayer(string name, IHand hand, IPlayerTypeBehavior playerTypeBehavior, IBlackJackConsoleService consoleService, IInputService inputService)
                                    : base(name, hand, playerTypeBehavior, consoleService)
        {
            _inputService = inputService;
        }

        public override string GetDecision()
        {
            return _inputService.GetHitOrStandDecision(this.Name);
        }
    }
}
