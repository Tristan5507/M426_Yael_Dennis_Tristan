using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    /// <summary>
    ///     Outputs Bingo game information to the console.
    /// </summary>
    public interface IBingoConsoleService
    {
        /// <summary>
        ///     Generates the console output for the current state of the Bingo game.
        /// </summary>
        /// <param name="players">The players participating in the game.</param>
        /// <param name="calledNumber">The number that has just been called.</param>
        void GenerateOutput(List<BingoPlayer> players, int calledNumber);

        /// <summary>
        ///     Generates the console output when a player achieves Bingo.
        /// </summary>
        /// <param name="player">The player that has won this game.</param>
        /// <param name="winningNumbers">The numbers that have lead the player to win.</param>
        void GenerateBingoOutput(BingoPlayer player, int[] winningNumbers);
    }
}
