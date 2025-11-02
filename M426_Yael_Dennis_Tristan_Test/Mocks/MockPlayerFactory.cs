using M426_Yael_Dennis_Tristan.Factories;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockPlayerFactory : IPlayerFactory
    {
        public List<BingoPlayer> CreateBingoPlayers(List<PlayerTemplate> templates)
        {
            throw new NotImplementedException();
        }

        public List<ABlackJackPlayer> CreateBlackJackPlayers(List<PlayerTemplate> templates)
        {
            throw new NotImplementedException();
        }
    }
}
