using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    /// <summary>
    ///     Outputs Casino game information to the console.
    /// </summary>
    public interface ICasinoConsoleService
    {
        /// <summary>
        ///     Asks the player for their name.
        /// </summary>
        void AskForName();

        /// <summary>
        ///     Generates the console output for the main menu.
        /// </summary>
        /// <param name="games">The possilby playable games.</param>
        void RenderMainMenu(Dictionary<int, string> games);

        /// <summary>
        ///     Generates the console output for the overall winner of the casino games.
        /// </summary>
        /// <param name="winner">The overall winner of the casino games.</param>
        void RenderOverallWinner(APlayer? winner);

        /// <summary>
        ///     Generates the console output for an invalid selection.
        /// </summary>
        void RenderInvalidSelection();

        /// <summary>
        ///     Generates a separator in the console output.
        /// </summary>
        void RenderSeparator();
    }
}
