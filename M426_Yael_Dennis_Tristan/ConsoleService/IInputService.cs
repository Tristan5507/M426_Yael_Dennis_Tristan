using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    /// <summary>
    ///     Service that handles all console input operations.
    /// </summary>
    public interface IInputService
    {
        /// <summary>
        ///     Gets the player templates based on user input.
        /// </summary>
        /// <returns>The player templates.</returns>
        List<PlayerTemplate> GetPlayerTemplates();

        /// <summary>
        ///     Gets the Hit or Stand decision from the player.
        /// </summary>
        /// <param name="playerName">The name of the player.</param>
        /// <returns>The player's decision.</returns>
        string GetHitOrStandDecision(string playerName);

        /// <summary>
        ///     Gets general user input from the console.
        /// </summary>
        /// <returns>The user's input.</returns>
        string GetUserInput();
    }
}
