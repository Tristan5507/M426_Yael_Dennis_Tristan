using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockBingoConsoleService : IBingoConsoleService
    {
        public void GenerateBingoOutput(List<BingoPlayer> winners)
        {
            throw new NotImplementedException();
        }

        public void GenerateOutput(List<BingoPlayer> players, int calledNumber)
        {
            throw new NotImplementedException();
        }
    }
}
