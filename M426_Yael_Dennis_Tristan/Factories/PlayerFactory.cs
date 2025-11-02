using M426_Yael_Dennis_Tristan.Bingo;
using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;
using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan.Factories
{
    /// <inheritdoc/>
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IRandom _random;
        private readonly IBlackJackConsoleService _blackJackConsoleService;
        private readonly IInputService _inputService;

        public PlayerFactory(IRandom random, IBlackJackConsoleService blackJackConsoleService, IInputService inputService)
        {
            _random = random;
            _blackJackConsoleService = blackJackConsoleService;
            _inputService = inputService;
        }

        /// <inheritdoc/>
        public List<ABlackJackPlayer> CreateBlackJackPlayers(List<PlayerTemplate> templates)
        {
            var players = new List<ABlackJackPlayer>();

            foreach (var template in templates)
            {
                var hand = new Hand();
                ABlackJackPlayer player = template.PlayerType switch
                {
                    PlayerType.Human => new HumanBlackJackPlayer(template.Name, hand, _blackJackConsoleService, _inputService),
                    PlayerType.Robot => new RobotBlackJackPlayer(template.Name, hand, _blackJackConsoleService),
                    _ => throw new InvalidOperationException("Invalid PlayerType"),
                };
                players.Add(player);
            }

            return players;
        }

        /// <inheritdoc/>
        public List<BingoPlayer> CreateBingoPlayers(List<PlayerTemplate> templates)
        {
            var players = new List<BingoPlayer>();

            foreach (var template in templates)
            {
                var board = new BingoBoard(_random);
                var player = new BingoPlayer(template.Name, board);
                players.Add(player);
            }

            return players;
        }
    }
}
