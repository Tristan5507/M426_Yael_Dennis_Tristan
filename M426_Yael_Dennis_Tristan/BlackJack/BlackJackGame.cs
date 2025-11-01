using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.BlackJack
{
    public class BlackJackGame : IGame
    {
        public List<APlayer> Players { get; }
        private readonly List<ABlackJackPlayer> _players;
        private readonly IBlackJackDealer _dealer;
        private readonly IBlackJackConsoleService _consoleService;

        public BlackJackGame(List<ABlackJackPlayer> players, IBlackJackDealer dealer, IBlackJackConsoleService consoleService)
        {
            _players = players;
            Players = players.Cast<APlayer>().ToList();
            _dealer = dealer;
            _consoleService = consoleService;
        }
        
        public GameResult Play()
        {
            _consoleService.RenderGameHeader(_players);

            _dealer.Shuffle();
            _dealer.ClearHand();

            foreach (var player in _players)
            {
                player.ClearHand();
            }

            // Deal initial cards
            for (int i = 0; i < 2; i++)
            {
                foreach (var player in _players)
                {
                    player.AddCard(_dealer.DrawCard());
                }
                _dealer.DealCard();
            }

            _consoleService.RenderInitialHands(_dealer.GetFirstCard(), _players);

            foreach (var player in _players)
            {
                player.PlayTurn(_dealer);
            }

            PlayDealerTurn();

            return DetermineWinner();
        }

        private void PlayDealerTurn()
        {
            _consoleService.RenderTurnHeader("Dealer");

            while (_dealer.GetHandValue() < 17)
            {
                _dealer.DealCard();
                _consoleService.RenderDealerDraw(_dealer.GetHandValue());
                Thread.Sleep(500);
            }

            _consoleService.RenderDealerFinalValue(_dealer.GetHandValue());
        }

        private GameResult DetermineWinner()
        {
            int dealerValue = _dealer.GetHandValue();
            var result = new GameResult();

            _consoleService.RenderResults(_players, dealerValue);

            foreach (var player in _players)
            {
                int playerValue = player.GetHandValue();
                
                if (playerValue > 21)
                    continue;
                
                if (dealerValue <= 21 && playerValue <= dealerValue)
                    continue;
                
                result.Winners.Add(player);
            }

            return result;
        }
    }
}
