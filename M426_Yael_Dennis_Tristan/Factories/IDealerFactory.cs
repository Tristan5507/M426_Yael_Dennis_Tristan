using M426_Yael_Dennis_Tristan.BlackJack;

namespace M426_Yael_Dennis_Tristan.Factories
{
    /// <summary>
    ///     Factory for creating dealer instances.
    /// </summary>
    public interface IDealerFactory
    {
        /// <summary>
        ///     Creates a new instance of a BlackJack dealer.
        /// </summary>
        /// <returns>A new instance of a BlackJack dealer.</returns>
        IBlackJackDealer CreateBlackJackDealer();
    }
}
