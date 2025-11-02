using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan.Factories
{
    /// <inheritdoc/>
    public class DealerFactory : IDealerFactory
    {
        private readonly IRandom _random;

        public DealerFactory(IRandom random)
        {
            _random = random;
        }

        /// <inheritdoc/>
        public IBlackJackDealer CreateBlackJackDealer()
        {
            var deck = new Deck(_random);
            var hand = new Hand();
            return new BlackJackDealer(deck, hand);
        }
    }
}
