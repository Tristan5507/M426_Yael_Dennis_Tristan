using M426_Yael_Dennis_Tristan;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockGame : IGame
    {
        public IEnumerable<APlayer> Players => throw new NotImplementedException();

        public GameResult Play()
        {
            throw new NotImplementedException();
        }
    }
}
