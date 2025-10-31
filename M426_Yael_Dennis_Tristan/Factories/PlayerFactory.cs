using M426_Yael_Dennis_Tristan.Bingo;
using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.Players;
using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IRandomNumberGenerator _random;

        public PlayerFactory(IRandomNumberGenerator random)
        {
            _random = random;
        }

        public List<BlackJackPlayer> CreateBlackJackPlayers(List<PlayerTemplate> templates)
        {
            var players = new List<BlackJackPlayer>();

            foreach (var template in templates)
            {
                var hand = new Hand();
                var player = new BlackJackPlayer(template, hand);
                players.Add(player);
            }

            return players;
        }

        public List<BingoPlayer> CreateBingoPlayers(List<PlayerTemplate> templates)
        {
            var players = new List<BingoPlayer>();

            foreach (var template in templates)
            {
                var board = new BingoBoard(_random);
                var player = new BingoPlayer(template, board);
                players.Add(player);
            }

            return players;
        }
    }
}
