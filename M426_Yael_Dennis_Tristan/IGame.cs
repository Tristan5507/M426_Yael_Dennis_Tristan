namespace M426_Yael_Dennis_Tristan
{
    /// <summary>
    ///     A game that can be played.
    /// </summary>
    public interface IGame
    {
        /// <summary>
        ///     Executes the game logic.
        /// </summary>
        /// <returns>The result of the game.</returns>
        public GameResult Play();
    }
}
