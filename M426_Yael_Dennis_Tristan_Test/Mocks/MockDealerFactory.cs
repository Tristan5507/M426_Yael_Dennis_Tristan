using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.Factories;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockDealerFactory : IDealerFactory
    {
        public IBlackJackDealer CreateBlackJackDealer()
        {
            throw new NotImplementedException();
        }
    }
}
