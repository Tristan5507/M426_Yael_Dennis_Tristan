using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan.Factories
{
    public class DealerFactory : IDealerFactory
    {
        private readonly IRandomNumberGenerator _random;

        public DealerFactory(IRandomNumberGenerator random)
        {
            _random = random;
        }

        public IBlackJackDealer CreateBlackJackDealer()
        {
            var deck = new Deck(_random);
            var hand = new Hand();
            return new BlackJackDealer(deck, hand);
        }
    }
}
