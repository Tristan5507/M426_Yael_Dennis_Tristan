using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    public class BlackJackConsoleService : IBlackJackConsoleService
    {
        public void RenderGameHeader(IEnumerable<BlackJackPlayer> players)
        {
            Console.WriteLine("\n=== BLACKJACK ===");
            Console.WriteLine($"Players: {string.Join(", ", players.Select(p => p.Name))}");
        }

        public void RenderInitialHands(Card dealerVisibleCard, IEnumerable<BlackJackPlayer> players)
        {
            Console.WriteLine($"\nDealer shows: {dealerVisibleCard.Rank} of {dealerVisibleCard.Suit}");

            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name}'s hand value: {player.GetHandValue()}");
            }
        }

        public void RenderPlayerTurnHeader(string playerName)
        {
            Console.WriteLine($"\n--- {playerName}'s turn ---");
        }

        public void RenderCardDraw(string playerName, Card card, int handValue)
        {
            Console.WriteLine($"{playerName} drew: {card.Rank} of {card.Suit}");
            Console.WriteLine($"Hand value: {handValue}");
        }

        public void RenderBust(string playerName)
        {
            Console.WriteLine($"{playerName} busts!");
        }

        public void RenderRobotDecision(string decision)
        {
            Console.WriteLine($"Robot decides: {decision}");
        }

        public void RenderDealerTurnHeader()
        {
            Console.WriteLine("\n--- Dealer's turn ---");
        }

        public void RenderDealerDraw(int handValue)
        {
            Console.WriteLine($"Dealer draws. Hand value: {handValue}");
        }

        public void RenderDealerFinalValue(int handValue)
        {
            Console.WriteLine($"Dealer final value: {handValue}");
        }

        public void RenderResults(IEnumerable<BlackJackPlayer> players, int dealerValue)
        {
            Console.WriteLine("\n=== RESULTS ===");

            foreach (var player in players)
            {
                int playerValue = player.GetHandValue();
                string result = DetermineResult(playerValue, dealerValue);

                Console.WriteLine($"{player.Name}: {playerValue} - {result}");
            }
        }

        public void RenderOverallWinner(IPlayer? winner)
        {
            Console.WriteLine();
            if (winner != null)
            {
                Console.WriteLine($"*** Overall winner: {winner.Name} ***");
            }
            else
            {
                Console.WriteLine("*** No clear winner ***");
            }
        }

        private string DetermineResult(int playerValue, int dealerValue)
        {
            if (playerValue > 21)
            {
                return "BUST - Dealer wins!";
            }
            else if (dealerValue > 21)
            {
                return "WIN - Dealer busts!";
            }
            else if (playerValue > dealerValue)
            {
                return "WIN!";
            }
            else if (dealerValue > playerValue)
            {
                return "LOSE!";
            }
            else
            {
                return "PUSH!";
            }
        }
    }
}
