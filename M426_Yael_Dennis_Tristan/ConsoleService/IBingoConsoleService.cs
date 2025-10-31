using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    /// <summary>
    ///     Handles the console output for the Bingo game.
    /// </summary>
    public interface IBingoConsoleService
    {
        /// <summary>
        ///     Generates the console output for the current state of the Bingo game.
        /// </summary>
        /// <param name="calledNumber">The number that has just been called.</param>
        /// <param name="players">The players participating in this game.</param>
        void GenerateOutput(int calledNumber, List<BingoPlayer> players);

        /// <summary>
        ///     Generates the console oupt when a player achieves Bingo.
        /// </summary>
        /// <param name="player">The player that has won this game.</param>
        /// <param name="winningNumbers">The numbers that lead the player to win.</param>
        void GenerateBingoOutput(BingoPlayer player, int[] winningNumbers);
    }
}
