namespace M426_Yael_Dennis_Tristan.Bingo
{
    /// <summary>
    ///     A player's bingo board.
    /// </summary>
    public interface IBingoBoard
    {
        /// <summary>
        ///     The fields on the bingo board.
        /// </summary>
        BingoField[,] Fields { get; }

        /// <summary>
        ///     Marks a number on the bingo board.
        /// </summary>
        /// <param name="number">The number that is to be marked.</param>
        void MarkNumber(int number);

        /// <summary>
        ///     Indicates whether the board has a bingo.
        /// </summary>
        /// <returns>Wether the board has a bingo.</returns>
        bool HasBingo();

        /// <summary>
        ///     Gets the numbers, that made the bingo.
        /// </summary>
        /// <returns>The winning numbers.</returns>
        int[] GetWinningNumbers();
    }
}
