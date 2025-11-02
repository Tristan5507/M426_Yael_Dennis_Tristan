using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    /// <inheritdoc/>
    public class BlackJackConsoleService : IBlackJackConsoleService
    {
        /// <inheritdoc/>
        public void RenderGameHeader(List<ABlackJackPlayer> players)
        {
            Console.WriteLine("\n=== BLACKJACK ===");
            Console.WriteLine($"Players: {string.Join(", ", players.Select(p => p.Name))}");
        }

        /// <inheritdoc/>
        public void RenderInitialHands(Card dealerVisibleCard, List<ABlackJackPlayer> players)
        {
            Console.WriteLine($"\nDealer shows: {dealerVisibleCard.Suit} {dealerVisibleCard.Rank}");

            foreach (var player in players)
            {
                Console.WriteLine($"{player.Name}'s hand value: {player.GetHandValue()}");
            }
        }

        /// <inheritdoc/>
        public void RenderTurnHeader(string playerName)
        {
            Console.WriteLine($"\n--- {playerName}'s turn ---");
        }

        /// <inheritdoc/>
        public void RenderCardDraw(string playerName, Card card, int handValue)
        {
            Console.WriteLine($"{playerName} drew: {card.Suit} {card.Rank}");
            Console.WriteLine($"Hand value: {handValue}");
        }

        /// <inheritdoc/>
        public void RenderBust(string playerName)
        {
            Console.WriteLine($"{playerName} busts!");
        }

        /// <inheritdoc/>
        public void RenderRobotDecision(string decision)
        {
            Console.WriteLine($"Robot decides: {decision}");
        }

        /// <inheritdoc/>
        public void RenderDealerDraw(int handValue)
        {
            Console.WriteLine($"Dealer draws. Hand value: {handValue}");
        }

        /// <inheritdoc/>
        public void RenderDealerFinalValue(int handValue)
        {
            Console.WriteLine($"Dealer final value: {handValue}");
        }

        /// <inheritdoc/>
        public void RenderResults(List<ABlackJackPlayer> players, int dealerValue)
        {
            Console.WriteLine("\n=== RESULTS ===");

            foreach (var player in players)
            {
                int playerValue = player.GetHandValue();
                string result = DetermineResult(playerValue, dealerValue);

                Console.WriteLine($"{player.Name}: {playerValue} - {result}");
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
