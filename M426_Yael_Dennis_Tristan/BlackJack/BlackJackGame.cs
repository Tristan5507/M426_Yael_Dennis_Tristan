using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.BlackJack
{
    public class BlackJackGame : IGame
    {
        private readonly List<ABlackJackPlayer> _players;
        private readonly IBlackJackDealer _dealer;
        private readonly IBlackJackConsoleService _consoleService;

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

            // Deal initial cards
            for (int i = 0; i < 2; i++)
            {
                foreach (var player in _players)
                {
                    player.AddCard(_dealer.DrawCard());
                }
                _dealer.DealCard();
            }

            // Show initial game state
            _consoleService.RenderGameState(_dealer, _players, -1, true);

            // Player turns
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

            Console.WriteLine($"\n--- {player.Name}'s Turn ---");
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

                        Console.WriteLine($"\n{player.Name} drew: {card.Suit} {card.Rank} → Total: {player.GetHandValue()}");

                        if (player.GetHandValue() > 21)
                        {
                            Console.WriteLine($"{player.Name} BUSTS!");
                        }

                        Thread.Sleep(800);
                        _consoleService.RenderGameState(_dealer, _players, playerIndex, true);
                    }
                }
                else
                {
                    Console.WriteLine($"\n{player.Name} stands at {player.GetHandValue()}");
                    Thread.Sleep(500);
                    break;
                }
            }
        }

        private void PlayDealerTurn()
        {
            Console.WriteLine("\n--- Dealer's Turn ---");
            Thread.Sleep(500);
            _consoleService.RenderGameState(_dealer, _players, -1, false);

            while (_dealer.GetHandValue() < 17)
            {
                var card = _dealer.DealCard();
                if (card != null)
                {
                    Console.WriteLine($"\nDealer draws: {card.Suit} {card.Rank} → Total: {_dealer.GetHandValue()}");
                    Thread.Sleep(800);
                    _consoleService.RenderGameState(_dealer, _players, -1, false);
                }
            }

            Console.WriteLine($"\nDealer stands at {_dealer.GetHandValue()}");
            Thread.Sleep(1000);
        }

        private GameResult DetermineWinner()
        {
            int dealerValue = _dealer.GetHandValue();
            ABlackJackPlayer? winner = null;
            int bestScore = 0;

            _consoleService.RenderResults(_players, dealerValue);

            foreach (var player in _players)
            {
                int playerValue = player.GetHandValue();

                if (playerValue > 21) continue;
                if (dealerValue <= 21 && playerValue <= dealerValue) continue;
                if (playerValue <= bestScore) continue;
                bestScore = playerValue;
                winner = player;
            }

            return new GameResult { Winner = winner };
        }
    }
}
