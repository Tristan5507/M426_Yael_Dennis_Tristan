using M426_Yael_Dennis_Tristan.BlackJack;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockDeck : IDeck
    {
        public Card? Draw()
        {
            throw new NotImplementedException();
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }
    }
}
