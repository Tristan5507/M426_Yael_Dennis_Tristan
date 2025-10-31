using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Factories;
using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Composition Root - Hier und NUR hier werden Dependencies erstellt

            // 1. Utilities erstellen
            var random = new RandomNumberGenerator();

            // 2. Services erstellen
            var inputService = new InputService();
            var casinoConsoleService = new CasinoConsoleService();
            var blackJackConsoleService = new BlackJackConsoleService();
            var bingoConsoleService = new BingoConsoleService();

            // 3. Factories erstellen
            var playerFactory = new PlayerFactory(random);
            var dealerFactory = new DealerFactory(random);
            var gameFactory = new GameFactory(
                inputService,
                blackJackConsoleService,
                bingoConsoleService,
                playerFactory,
                dealerFactory,
                random
            );

            // 4. Casino erstellen und starten
            var casino = new Casino(
                casinoConsoleService,
                blackJackConsoleService,
                gameFactory
            );

            casino.Play();
        }
    }
}
