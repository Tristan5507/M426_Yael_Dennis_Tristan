using M426_Yael_Dennis_Tristan.ConsoleService;

namespace M426_Yael_Dennis_Tristan.Players
{
    public class HumanPlayerBehavior : IPlayerTypeBehavior
    {
        private readonly IInputService _inputService;
        private readonly ICurrencyConsoleService _currencyConsoleService;

        public HumanPlayerBehavior(IInputService inputService, ICurrencyConsoleService currencyConsoleService)
        {
            _inputService = inputService;
            _currencyConsoleService = currencyConsoleService;
        }

        public int GetBet(APlayer player)
        {
            int input = _inputService.GetUserInputAsInt("Bitte geben Sie Ihren Einsatz an Jettons ein: ");
            if (input > 0 && input <= player.Balance)
            {
                return input;
            }

            _currencyConsoleService.RenderInvalidBet();

            return GetBet(player);
        }

        public void OnBalanceChanged(APlayer player, List<IJetonObserver> observers)
        {
            observers.ForEach(observer => observer.Notify(player));
        }
    }
}
