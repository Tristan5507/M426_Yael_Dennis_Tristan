using M426_Yael_Dennis_Tristan;
using M426_Yael_Dennis_Tristan.Factories;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockeGameFactory : IGameFactory
    {
        public IGame? CreateGame(int gameNumber, string playerName)
        {
            throw new NotImplementedException();
        }
    }
}
