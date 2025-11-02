using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.BlackJack
{
    /// <inheritdoc/>
    public class BlackJackGame : IGame
    {
        private readonly List<ABlackJackPlayer> _players;
        private readonly IBlackJackDealer _dealer;
        private readonly IBlackJackConsoleService _consoleService;

        /// <inheritdoc/>
        public IEnumerable<APlayer> Players => _players.Cast<APlayer>();

        public BlackJackGame(List<ABlackJackPlayer> players, IBlackJackDealer dealer, IBlackJackConsoleService consoleService)
        {
            _players = players;
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

            for (int i = 0; i < 2; i++)
            {
                foreach (var player in _players)
                {
                    player.AddCard(_dealer.DrawCard());
                }
                _dealer.DealCard();
            }

            _consoleService.RenderGameState(_dealer, _players, -1, true);

            for (int i = 0; i < _players.Count; i++)
            {
                PlayPlayerTurn(i);
            }

            PlayDealerTurn();

            return DetermineWinner();
        }

        private void PlayPlayerTurn(int playerIndex)
        {
            var player = _players[playerIndex];

            Console.WriteLine($"\n--- {player.Name} ist am Zug ---");
            Thread.Sleep(500);
            _consoleService.RenderGameState(_dealer, _players, playerIndex, true);

            while (player.GetHandValue() < 21)
            {
                string choice = player.GetDecision();

                if (choice == "h")
                {
                    var card = _dealer.DrawCard();
                    if (card != null)
                    {
                        player.AddCard(card);

                        Console.WriteLine($"\n{player.Name} zieht: {card.Suit} {card.Rank} - Total: {player.GetHandValue()}");

                        if (player.GetHandValue() > 21)
                        {
                            Console.WriteLine($"{player.Name} ist ÜBERKAUFT!");
                        }

                        Thread.Sleep(800);
                        _consoleService.RenderGameState(_dealer, _players, playerIndex, true);
                    }
                }
                else
                {
                    Console.WriteLine($"\n{player.Name} bleibt bei {player.GetHandValue()}");
                    Thread.Sleep(500);
                    break;
                }
            }
        }

        private void PlayDealerTurn()
        {
            Console.WriteLine("\n--- Dealer ist am Zug ---");
            Thread.Sleep(500);
            _consoleService.RenderGameState(_dealer, _players, -1, false);

            while (_dealer.GetHandValue() < 17)
            {
                var card = _dealer.DealCard();
                if (card != null)
                {
                    Console.WriteLine($"\nDealer zieht: {card.Suit} {card.Rank} → Total: {_dealer.GetHandValue()}");
                    Thread.Sleep(800);
                    _consoleService.RenderGameState(_dealer, _players, -1, false);
                }
            }

            Console.WriteLine($"\nDealer bleibt bei {_dealer.GetHandValue()}");
            Thread.Sleep(1000);
        }

        private GameResult DetermineWinner()
        {
            int dealerValue = _dealer.GetHandValue();
            var result = new GameResult();

            foreach (var player in _players)
            {
                int playerValue = player.GetHandValue();
                BlackJackPlayerResult playerResult;

                // Bestimme das Ergebnis basierend auf BlackJack-Regeln
                if (playerValue > 21)
                {
                    playerResult = BlackJackPlayerResult.Bust;
                }
                else if (dealerValue > 21)
                {
                    playerResult = BlackJackPlayerResult.Win;
                    result.Winners.Add(player);
                }
                else if (playerValue > dealerValue)
                {
                    playerResult = BlackJackPlayerResult.Win;
                    result.Winners.Add(player);
                }
                else if (playerValue == dealerValue)
                {
                    playerResult = BlackJackPlayerResult.Push;
                }
                else
                {
                    playerResult = BlackJackPlayerResult.Lose;
                }

                result.PlayerResults[player] = playerResult;
            }

            _consoleService.RenderResults(_players, dealerValue, result.PlayerResults);

            return result;
        }
    }
}
