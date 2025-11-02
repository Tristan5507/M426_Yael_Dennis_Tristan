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
        private readonly IJetonObserver _observer;

        public PlayerFactory(IRandom random, IBlackJackConsoleService blackJackConsoleService, IInputService inputService, IJetonObserver observer)
        {
            _random = random;
            _blackJackConsoleService = blackJackConsoleService;
            _inputService = inputService;
            _observer = observer;
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
                    PlayerType.Human => new HumanBlackJackPlayer(template.Name, hand, new HumanPlayerBehavior(_inputService), _blackJackConsoleService, _inputService),
                    PlayerType.Robot => new RobotBlackJackPlayer(template.Name, hand, new RobotPlayerBehavior(_random), _blackJackConsoleService),
                    _ => throw new InvalidOperationException("Invalid PlayerType"),
                };
                player.Attach(_observer);
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
                IPlayerTypeBehavior behavior = template.PlayerType switch
                {
                    PlayerType.Human => new HumanPlayerBehavior(_inputService),
                    PlayerType.Robot => new RobotPlayerBehavior(_random),
                    _ => throw new InvalidOperationException("Invalid PlayerType"),
                };
                var player = new BingoPlayer(template.Name, behavior, board);
                player.Attach(_observer);
                players.Add(player);
            }

            return players;
        }
    }
}
