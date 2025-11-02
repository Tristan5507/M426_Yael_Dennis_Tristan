namespace M426_Yael_Dennis_Tristan.BlackJack
{
    /// <summary>
    ///     The dealer for a game of BlackJack.
    /// </summary>
    public interface IBlackJackDealer
    {
        /// <summary>
        ///     Draws a card from the deck and adds it to the dealer's hand.
        /// </summary>
        /// <returns>The card that was drawn and added to the hand.</returns>
        Card? DealCard();

        /// <summary>
        ///     Shuffles the deck.
        /// </summary>
        void Shuffle();

        /// <summary>
        ///     Gets the value of the dealer's hand.
        /// </summary>
        /// <returns>The value of the dealer's hand.</returns>
        int GetHandValue();

        /// <summary>
        ///     Clears the dealer's hand.
        /// </summary>
        void ClearHand();

        /// <summary>
        ///     Draws a card from the dealer's deck.
        /// </summary>
        /// <returns>A card drawn from the dealer's deck.</returns>
        Card? DrawCard();

        /// <summary>
        ///     Gets the first card in the dealer's hand.
        /// </summary>
        /// <returns>The first card in the dealer's hand.</returns>
        Card GetFirstCard();

        /// <summary>
        ///     Gets all cards in the dealer's hand.
        /// </summary>
        /// <returns>List of all cards in the dealer's hand.</returns>
        List<Card> GetCards();
    }
}
