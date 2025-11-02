namespace M426_Yael_Dennis_Tristan.BlackJack
{
    /// <summary>
    ///     A hand in a card game, capable of holding cards and calculating their total value.
    /// </summary>
    public interface IHand
    {
        /// <summary>
        ///     Adds a card to the hand.
        /// </summary>
        /// <param name="card">The card that's to be added to the hand.</param>
        void AddCard(Card? card);

        /// <summary>
        ///     Calulates the value of the hand.
        /// </summary>
        /// <returns>The value of the hand.</returns>
        int GetValue();

        /// <summary>
        ///     Gets the first card in the hand.
        /// </summary>
        /// <returns>The first card in the hand.</returns>
        Card GetFirstCard();

        /// <summary>
        ///     Clears the hand of all cards.
        /// </summary>
        void Clear();

        /// <summary>
        ///     Gets all cards in the hand.
        /// </summary>
        /// <returns>List of all cards in the hand.</returns>
        List<Card> GetCards();
    }
}
