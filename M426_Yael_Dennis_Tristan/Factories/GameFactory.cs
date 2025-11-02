using M426_Yael_Dennis_Tristan.Bingo;
using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan.Factories
{
    /// <inheritdoc/>
    public class GameFactory : IGameFactory
    {
        private readonly IInputService _inputService;
        private readonly IBlackJackConsoleService _blackJackConsoleService;
        private readonly IBingoConsoleService _bingoConsoleService;
        private readonly IPlayerFactory _playerFactory;
        private readonly IDealerFactory _dealerFactory;
        private readonly IRandom _random;

        public GameFactory(IInputService inputService, IBlackJackConsoleService blackJackConsoleService,
                           IBingoConsoleService bingoConsoleService, IPlayerFactory playerFactory,
                           IDealerFactory dealerFactory, IRandom random)
        {
            _inputService = inputService;
            _blackJackConsoleService = blackJackConsoleService;
            _bingoConsoleService = bingoConsoleService;
            _playerFactory = playerFactory;
            _dealerFactory = dealerFactory;
            _random = random;
        }

        /// <inheritdoc/>
        public IGame? CreateGame(int gameNumber, string playerName)
        {
            return gameNumber switch
            {
                1 => CreateBlackJackGame(playerName),
                2 => CreateBingoGame(playerName),
                _ => null
            };
        }

        private IGame CreateBlackJackGame(string playerName)
        {
            var playerTemplates = _inputService.GetPlayerTemplates(playerName);
            var players = _playerFactory.CreateBlackJackPlayers(playerTemplates);
            var dealer = _dealerFactory.CreateBlackJackDealer();

            return new BlackJackGame(players, dealer, _blackJackConsoleService);
        }

        private IGame CreateBingoGame(string playerName)
        {
            var playerTemplates = _inputService.GetPlayerTemplates(playerName);
            var players = _playerFactory.CreateBingoPlayers(playerTemplates);
            var numberCaller = new NumberCaller(1, 75, _random);

            return new BingoGame(players, numberCaller, _bingoConsoleService);
        }
    }
}
