using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.Factories
{
    /// <summary>
    ///     Factory for creating player instances.
    /// </summary>
    public interface IPlayerFactory
    {
        /// <summary>
        ///     Creates a list of new instances of BlackJack players.
        /// </summary>
        /// <param name="templates">Template to create the players by.</param>
        /// <returns>A list of new instances of BlackJack players.</returns>
        List<ABlackJackPlayer> CreateBlackJackPlayers(List<PlayerTemplate> templates);

        /// <summary>
        ///     Creates a list of new instances of Bingo players.
        /// </summary>
        /// <param name="templates">Template to create the players by.</param>
        /// <returns>A list of new instances of Bingo players.</returns>
        List<BingoPlayer> CreateBingoPlayers(List<PlayerTemplate> templates);
    }
}
