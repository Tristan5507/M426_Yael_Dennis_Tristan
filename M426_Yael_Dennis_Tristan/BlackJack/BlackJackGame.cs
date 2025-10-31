using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.BlackJack
{
    public class BlackJackGame : IGame
    {
        private readonly IBlackJackDealer _dealer;
        private readonly List<BlackJackPlayer> _players;
        private readonly IBlackJackConsoleService _consoleService;

        public BlackJackGame(IBlackJackDealer dealer, List<BlackJackPlayer> players, IBlackJackConsoleService consoleService)
        {
            _dealer = dealer;
            _players = players;
            _consoleService = consoleService;
        }
        

        public GameResult Play()
        {
            // Render game header
            _consoleService.RenderGameHeader(_players);

            // Setup game
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
                    player.AddCard(_dealer.Deck.Draw());
                }
                _dealer.DealCard();
            }

            // Show initial state
            _consoleService.RenderInitialHands(_dealer.Hand.Cards[0], _players);

            // Players play
            foreach (var player in _players)
            {
                PlayPlayerTurn(player);
            }

            // Dealer plays
            PlayDealerTurn();

            // Determine and display winner
            return DetermineWinner();
        }

        private void PlayPlayerTurn(BlackJackPlayer player)
        {
            _consoleService.RenderPlayerTurnHeader(player.Name);

            while (player.GetHandValue() < 21)
            {
                string choice;

                if (player.PlayerType == PlayerType.Human)
                {
                    Console.Write($"{player.Name}, Hit or Stand? (h/s): ");
                    choice = Console.ReadLine()?.ToLower() ?? "s";
                }
                else // Robot
                {
                    choice = player.GetHandValue() < 17 ? "h" : "s";
                    _consoleService.RenderRobotDecision(choice == "h" ? "Hit" : "Stand");
                    Thread.Sleep(500);
                }

                if (choice == "h")
                {
                    var card = _dealer.Deck.Draw();
                    if (card != null)
                    {
                        player.AddCard(card);
                        _consoleService.RenderCardDraw(player.Name, card, player.GetHandValue());

                        if (player.GetHandValue() > 21)
                        {
                            _consoleService.RenderBust(player.Name);
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void PlayDealerTurn()
        {
            _consoleService.RenderDealerTurnHeader();

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
            IPlayer? winner = null;
            int bestScore = 0;

            // Render results using ConsoleService
            _consoleService.RenderResults(_players, dealerValue);

            // Determine overall winner
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
