using M426_Yael_Dennis_Tristan.ConsoleService;

namespace M426_Yael_Dennis_Tristan.Players
{
    public class HumanPlayerBehavior : IPlayerTypeBehavior
    {
        private readonly IInputService _inputService;
        public HumanPlayerBehavior(IInputService inputService)
        {
            _inputService = inputService;
        }

        public int GetBet(APlayer player)
        {
            int input = _inputService.GetUserInputAsInt("Bitte geben Sie Ihren Einsatz an Jettons ein: ");
            if (input > 0 && input <= player.Balance)
            {
                return input;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ungültiger Einsatz. Bitte versuchen Sie es erneut.");
            Console.ResetColor();

            return GetBet(player);
        }
    }
}
