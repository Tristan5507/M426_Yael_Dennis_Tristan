using M426_Yael_Dennis_Tristan.Bingo;
using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IInputService _inputService;
        private readonly IBlackJackConsoleService _blackJackConsoleService;
        private readonly IBingoConsoleService _bingoConsoleService;
        private readonly IPlayerFactory _playerFactory;
        private readonly IDealerFactory _dealerFactory;
        private readonly IRandomNumberGenerator _random;

        public GameFactory(
            IInputService inputService,
            IBlackJackConsoleService blackJackConsoleService,
            IBingoConsoleService bingoConsoleService,
            IPlayerFactory playerFactory,
            IDealerFactory dealerFactory,
            IRandomNumberGenerator random)
        {
            _inputService = inputService;
            _blackJackConsoleService = blackJackConsoleService;
            _bingoConsoleService = bingoConsoleService;
            _playerFactory = playerFactory;
            _dealerFactory = dealerFactory;
            _random = random;
        }

        public IGame? CreateGame(int gameNumber)
        {
            return gameNumber switch
            {
                1 => CreateBlackJackGame(),
                2 => CreateBingoGame(),
                _ => null
            };
        }

        private IGame CreateBlackJackGame()
        {
            var playerTemplates = _inputService.GetPlayerTemplates();
            var players = _playerFactory.CreateBlackJackPlayers(playerTemplates);
            var dealer = _dealerFactory.CreateBlackJackDealer();

            return new BlackJackGame(dealer, players, _blackJackConsoleService);
        }

        private IGame CreateBingoGame()
        {
            var playerTemplates = _inputService.GetPlayerTemplates();
            var players = _playerFactory.CreateBingoPlayers(playerTemplates);
            var numberCaller = new NumberCaller(1, 75, _random);

            return new BingoGame(numberCaller, players, _bingoConsoleService);
        }
    }
}
