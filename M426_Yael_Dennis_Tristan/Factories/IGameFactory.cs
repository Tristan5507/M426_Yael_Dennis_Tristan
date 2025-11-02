namespace M426_Yael_Dennis_Tristan.Factories
{
    /// <summary>
    ///     Factory for creating game instances.
    /// </summary>
    public interface IGameFactory
    {
        /// <summary>
        ///     Creates a new instance of a game based on a number.
        /// </summary>
        /// <param name="gameNumber">The number corresponding to a game.</param>
        /// <param name="playerName">The name of the human player.</param>
        /// <returns>A new instance of a game.</returns>
        IGame? CreateGame(int gameNumber, string playerName);
    }
}
