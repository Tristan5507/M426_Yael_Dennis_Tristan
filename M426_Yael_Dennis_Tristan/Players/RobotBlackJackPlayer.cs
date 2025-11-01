using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Currency;

namespace M426_Yael_Dennis_Tristan.Players
{
    public class RobotBlackJackPlayer : ABlackJackPlayer
    {
        public RobotBlackJackPlayer(string name, IHand hand, PlayerType playerType, IBlackJackConsoleService consoleService, IJettonService jettonService, IBettingService bettingService)
            : base(name, hand, playerType, consoleService, jettonService, bettingService)
        {
        }

        public override string GetDecision()
        {
            var choice = this.GetHandValue() < 17 ? "h" : "s";
            _consoleService.RenderRobotDecision(choice == "h" ? "Hit" : "Stand");
            Thread.Sleep(500);

            return choice;
        }
    }
}
