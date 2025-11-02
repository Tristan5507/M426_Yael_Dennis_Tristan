using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockCurrencyConsoleService : ICurrencyConsoleService
    {
        public void ClearLastRow()
        {
            throw new NotImplementedException();
        }

        public void PrintAt(int x, int y, string str)
        {
            throw new NotImplementedException();
        }

        public void RenderBalances(IEnumerable<APlayer> players)
        {
            throw new NotImplementedException();
        }

        public void RenderBetConfirmation(IEnumerable<APlayer> players)
        {
            throw new NotImplementedException();
        }

        public void RenderLoser(APlayer loser)
        {
            throw new NotImplementedException();
        }

        public void RenderWinner(APlayer winner)
        {
            throw new NotImplementedException();
        }

        public void RenderInvalidBet()
        {
        }
    }
}
