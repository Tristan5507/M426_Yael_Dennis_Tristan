namespace M426_Yael_Dennis_Tristan.Bingo
{
    /// <summary>
    ///     Calls numbers for a Bingo game.
    /// </summary>
    public interface INumberCaller
    {
        /// <summary>
        ///     Calls the next number in the Bingo game.
        /// </summary>
        /// <returns>The called number.</returns>
        public int CallNext();
    }
}
