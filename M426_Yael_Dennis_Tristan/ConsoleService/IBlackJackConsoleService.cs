using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    /// <summary>
    ///     Outputs BlackJack-specific information to the console.
    /// </summary>
    public interface IBlackJackConsoleService
    {
        /// <summary>
        ///     Generates the console output of the game header.
        /// </summary>
        /// <param name="players">The participating players.</param>
        void RenderGameHeader(List<ABlackJackPlayer> players);

        /// <summary>
        ///     Generates the console output of the initial hands.
        /// </summary>
        /// <param name="dealerVisibleCard">The dealer's visible card.</param>
        /// <param name="players">The participating players.</param>
        void RenderInitialHands(Card dealerVisibleCard, List<ABlackJackPlayer> players);

        /// <summary>
        ///     Generates the console output for the header of someones turn.
        /// </summary>
        /// <param name="playerName">The name of the player whose turn it is.</param>
        void RenderTurnHeader(string playerName);

        /// <summary>
        ///     Generates the console output for when a player draws a card.
        /// </summary>
        /// <param name="playerName">The name of the player whose turn it is.</param>
        /// <param name="card">The card the player drew.</param>
        /// <param name="handValue">The value of the player's hand.</param>
        void RenderCardDraw(string playerName, Card card, int handValue);

        /// <summary>
        ///     Generates the console output for when a player busts.
        /// </summary>
        /// <param name="playerName">The player who busted.</param>
        void RenderBust(string playerName);

        /// <summary>
        ///     Generates the console output for a robot player's decision.
        /// </summary>
        /// <param name="decision">The robot player's decision.</param>
        void RenderRobotDecision(string decision);

        /// <summary>
        ///     Generates the console output for when the dealer draws a card.
        /// </summary>
        /// <param name="handValue">The value of the dealer's hand.</param>
        void RenderDealerDraw(int handValue);

        /// <summary>
        ///     Generates the console output for the final value of the dealer's hand.
        /// </summary>
        /// <param name="handValue">The final value of the dealer's hand.</param>
        void RenderDealerFinalValue(int handValue);

        /// <summary>
        ///     Generates the console output for the results of the game.
        /// </summary>
        /// <param name="players">The players participating.</param>
        /// <param name="dealerValue">The value of the dealer.</param>
        /// <param name="results">The calculated results for each player.</param>
        void RenderResults(List<ABlackJackPlayer> players, int dealerValue, Dictionary<APlayer, BlackJackPlayerResult> results);

        /// <summary>
        ///     Renders the complete game state (dealer + all players).
        /// </summary>
        /// <param name="dealer">The dealer.</param>
        /// <param name="players">All players.</param>
        /// <param name="currentPlayerIndex">Index of current player (-1 if none).</param>
        /// <param name="hideDealerSecondCard">Whether to hide dealer's second card.</param>
        void RenderGameState(IBlackJackDealer dealer, List<ABlackJackPlayer> players, int currentPlayerIndex, bool hideDealerSecondCard);
    }
}
