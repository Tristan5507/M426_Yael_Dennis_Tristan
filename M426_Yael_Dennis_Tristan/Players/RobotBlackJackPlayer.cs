using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.ConsoleService;

namespace M426_Yael_Dennis_Tristan.Players
{
    public class RobotBlackJackPlayer : ABlackJackPlayer
    {
        public RobotBlackJackPlayer(string name, IHand hand, IPlayerTypeBehavior playerTypeBehavior, IBlackJackConsoleService consoleService)
                                    : base(name, hand, playerTypeBehavior, consoleService)
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
