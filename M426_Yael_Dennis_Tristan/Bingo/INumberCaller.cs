namespace M426_Yael_Dennis_Tristan.Bingo
{
    /// <summary>
    ///     Calls the numbers for a bingo game.
    /// </summary>
    public interface INumberCaller
    {
        /// <summary>
        ///     Calls the next number in the bingo game.
        /// </summary>
        /// <returns>The called number.</returns>
        public int CallNext();
    }
}
