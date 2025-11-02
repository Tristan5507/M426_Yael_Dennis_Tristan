using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    public class JetonDisplayHandler : IJetonObserver
    {
        private readonly ICurrencyConsoleService _consoleService;

        public JetonDisplayHandler(ICurrencyConsoleService consoleService)
        {
            _consoleService = consoleService;
        }

        public void Notify(APlayer player)
        {
            DisplayJetons(player);
        }

        private void DisplayJetons(APlayer player)
        {
            var jetonAmount = player.Balance;

            var output = $"Jetons: {jetonAmount}";
            CalculateStartCordinates(output, out int xCoordinate, out int yCoordinate);

            _consoleService.ClearLastRow();
            _consoleService.PrintAt(xCoordinate, yCoordinate, output);
        }

        private void CalculateStartCordinates(string str, out int x, out int y)
        {
            const int setOffset = 2;
            int textLength = str.Length;

            x = Console.WindowWidth - textLength;
            y = Console.WindowHeight - setOffset;
        }
    }
}
