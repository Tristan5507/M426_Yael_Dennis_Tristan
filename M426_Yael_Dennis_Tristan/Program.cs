using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Factories;
using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Utilities
            var random = new DefaultRandom();

            // Services 
            var inputService = new InputService();
            var casinoConsoleService = new CasinoConsoleService();
            var blackJackConsoleService = new BlackJackConsoleService();
            var bingoConsoleService = new BingoConsoleService();
            var currencyConsoleService = new CurrencyConsoleService();
            var jetonDisplayHandler = new JetonDisplayHandler(currencyConsoleService);

            // Factories 
            var playerFactory = new PlayerFactory(random, blackJackConsoleService, inputService, jetonDisplayHandler);
            var dealerFactory = new DealerFactory(random);
            var gameFactory = new GameFactory(
                inputService,
                blackJackConsoleService,
                bingoConsoleService,
                playerFactory,
                dealerFactory,
                random
            );

            // Casino 
            var casino = new Casino(
                casinoConsoleService,
                gameFactory,
                inputService,
                currencyConsoleService
            );

            casino.Play();
        }
    }
}
