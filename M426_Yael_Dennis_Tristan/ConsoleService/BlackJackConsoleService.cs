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
        public void RenderPlayerStand(string playerName, int handValue)
        {
            Console.WriteLine($"\n{playerName} bleibt bei {handValue}");
        }

        /// <inheritdoc/>
        public void RenderRobotDecision(string decision)
        {
            Console.WriteLine($"Robot decides: {decision}");
        }

        /// <inheritdoc/>
        public void RenderDealerTurnHeader()
        {
            Console.WriteLine("\n--- Dealer ist am Zug ---");
        }

        /// <inheritdoc/>
        public void RenderDealerCardDraw(Card card, int handValue)
        {
            Console.WriteLine($"\nDealer zieht: {card.Suit} {card.Rank} → Total: {handValue}");
        }

        /// <inheritdoc/>
        public void RenderDealerStand(int handValue)
        {
            Console.WriteLine($"\nDealer bleibt bei {handValue}");
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
        public void RenderResults(List<ABlackJackPlayer> players, int dealerValue, Dictionary<APlayer, BlackJackPlayerResult> results)
        {
            Console.WriteLine("\n=== ERGEBNISSE ===\n");

            foreach (var player in players)
            {
                int playerValue = player.GetHandValue();

                BlackJackPlayerResult playerResult = results[player];

                string resultText = GetResultText(playerResult, dealerValue);

                SetResultColor(playerResult);

                Console.WriteLine($"{player.Name}: {playerValue} - {resultText}");
                Console.ResetColor();
            }

            Console.WriteLine($"\nDealer: {dealerValue}{(dealerValue > 21 ? " - ÜBERKAUFT" : "")}");
        }

        /// <summary>
        /// Konvertiert das Spielergebnis in einen lesbaren deutschen Text.
        /// Diese Methode macht nur Formatierung, keine Logik.
        /// </summary>
        private string GetResultText(BlackJackPlayerResult result, int dealerValue)
        {
            return result switch
            {
                BlackJackPlayerResult.Bust => "ÜBERKAUFT - VERLOREN",
                BlackJackPlayerResult.Win when dealerValue > 21 => "GEWONNEN - Dealer überkauft",
                BlackJackPlayerResult.Win => "GEWONNEN",
                BlackJackPlayerResult.Lose => "VERLOREN",
                BlackJackPlayerResult.Push => "UNENTSCHIEDEN",
                _ => "UNBEKANNT"
            };
        }

        /// <summary>
        /// Setzt die Konsolenfarbe basierend auf dem Spielergebnis.
        /// </summary>
        private void SetResultColor(BlackJackPlayerResult result)
        {
            Console.ForegroundColor = result switch
            {
                BlackJackPlayerResult.Win => ConsoleColor.Green,
                BlackJackPlayerResult.Bust or BlackJackPlayerResult.Lose => ConsoleColor.Red,
                _ => ConsoleColor.White
            };
        }

        /// <inheritdoc/>
        public void RenderGameState(IBlackJackDealer dealer, List<ABlackJackPlayer> players, int currentPlayerIndex, bool hideDealerSecondCard)
        {
            Console.Clear();
            Console.WriteLine("\n=== BLACKJACK ===");

            RenderDealer(dealer, hideDealerSecondCard);
            RenderPlayers(players, currentPlayerIndex);

            Console.WriteLine();
        }

        private void RenderDealer(IBlackJackDealer dealer, bool hideSecondCard)
        {
            Console.WriteLine("\nDEALER");

            var cards = dealer.GetCards();
            if (cards.Count == 0)
            {
                Console.WriteLine("Karten:    (keine)");
                return;
            }

            Console.Write("Karten:    ");
            Console.Write(FormatCard(cards[0]));

            if (hideSecondCard && cards.Count > 1)
            {
                Console.WriteLine("  [HIDDEN]");
                Console.WriteLine("Total:     ??");
            }
            else
            {
                for (int i = 1; i < cards.Count; i++)
                {
                    Console.Write("  " + FormatCard(cards[i]));
                }
                Console.WriteLine();
                Console.WriteLine($"Total:     {dealer.GetHandValue()}");
            }
        }

        private void RenderPlayers(List<ABlackJackPlayer> players, int currentPlayerIndex)
        {
            if (players.Count == 0) return;

            Console.WriteLine();

            for (int i = 0; i < players.Count; i++)
            {
                bool isCurrent = i == currentPlayerIndex;
                bool isBust = players[i].GetHandValue() > 21;

                SetPlayerColor(players[i].GetHandValue(), isCurrent, isBust);
                Console.Write($"{players[i].Name,-20} ");
                Console.ResetColor();
            }
            Console.WriteLine();

            int maxCards = players.Max(p => p.GetCards().Count);

            for (int cardIndex = 0; cardIndex < maxCards; cardIndex++)
            {
                for (int playerIndex = 0; playerIndex < players.Count; playerIndex++)
                {
                    var cards = players[playerIndex].GetCards();
                    string cardText = "";

                    if (cardIndex < cards.Count)
                    {
                        string prefix = cardIndex == 0 ? "Karten: " : "        ";
                        cardText = $"{prefix}{FormatCard(cards[cardIndex])}";
                    }

                    Console.Write($"{cardText,-20} ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < players.Count; i++)
            {
                int handValue = players[i].GetHandValue();
                bool isBust = handValue > 21;
                bool isBlackjack = handValue == 21 && players[i].GetCards().Count == 2;

                string status = "";
                if (isBust) status = " ÜBERKAUFT";
                else if (isBlackjack) status = " BLACKJACK";

                SetPlayerColor(handValue, i == currentPlayerIndex, isBust);
                Console.Write($"Total:  {handValue}{status,-12} ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        private string FormatCard(Card card)
        {
            return $"{card.Suit} {card.Rank}";
        }

        private void SetPlayerColor(int handValue, bool isCurrent, bool isBust)
        {
            if (isBust)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (handValue == 21)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (isCurrent)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
