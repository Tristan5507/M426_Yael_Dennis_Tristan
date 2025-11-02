using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockCasinoConsoleService : ICasinoConsoleService
    {
        public void RenderInvalidSelection()
        {
            throw new NotImplementedException();
        }

        public void RenderLogo()
        {
            throw new NotImplementedException();
        }

        public void RenderMainMenu(Dictionary<int, string> games)
        {
            throw new NotImplementedException();
        }

        public void RenderOverallWinner(APlayer? winner)
        {
            throw new NotImplementedException();
        }

        public void RenderSeparator()
        {
            throw new NotImplementedException();
        }
    }
}
