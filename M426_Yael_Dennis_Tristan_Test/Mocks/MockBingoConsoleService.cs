using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockBingoConsoleService : IBingoConsoleService
    {
        public readonly List<string> Messages = new();
        public readonly List<List<BingoPlayer>> GenerateBingoOuputCalled = new();
        public readonly List<Tuple<List<BingoPlayer>, int>> GenerateOutputCalled = new();
        public bool CursorVisible = true;

        public void GenerateBingoOutput(List<BingoPlayer> winners)
        {
            GenerateBingoOuputCalled.Add(winners);
        }

        public void GenerateOutput(List<BingoPlayer> players, int calledNumber)
        {
            GenerateOutputCalled.Add(new Tuple<List<BingoPlayer>, int>(players, calledNumber));
        }

        public void SetCursorInvisible()
        {
            CursorVisible = false;
        }

        public void WriteOutput(string message)
        {
            Messages.Add(message);
        }

        public void RenderNoMoreNumbers()
        {
        }
    }
}
