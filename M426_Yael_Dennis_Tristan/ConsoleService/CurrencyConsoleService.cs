using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    /// <inheritdoc/>
    public class CurrencyConsoleService : ICurrencyConsoleService
    {
        public void RenderBalances(IEnumerable<APlayer> players)
        {
            Console.WriteLine();
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name}: Aktuelles Guthaben: {player.Balance} Jettons");
            }
            Console.WriteLine();
        }

        public void RenderBetConfirmation(IEnumerable<APlayer> players)
        {
            Console.WriteLine();
            Console.WriteLine("Gebotene Jettons: ");
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name}: Gebotene Jettons: {player.CurrentBet}");
            }
        }

        public void RenderWinner(APlayer winner)
        {
            Console.WriteLine($"{winner.Name} gewinnt!");
        }

        public void RenderLoser(APlayer loser)
        {
            Console.WriteLine($"{loser.Name} verliert.");
        }
    }
}
