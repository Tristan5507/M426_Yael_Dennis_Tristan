using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan
{
    public interface IGame
    {
        /// <summary>
        ///     Executes the game logic.
        /// </summary>
        /// <returns>The result of the game.</returns>
        public GameResult Play();
    }
}
