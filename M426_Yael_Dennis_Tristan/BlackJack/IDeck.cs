namespace M426_Yael_Dennis_Tristan.BlackJack
{
    /// <summary>
    ///     A deck of playing cards.
    /// </summary>
    public interface IDeck
    {
        /// <summary>
        ///     Shuffles the deck of cards.
        /// </summary>
        void Shuffle();

        /// <summary>
        ///     Draws a card from the deck.
        /// </summary>
        /// <returns></returns>
        Card? Draw();
    }
}
