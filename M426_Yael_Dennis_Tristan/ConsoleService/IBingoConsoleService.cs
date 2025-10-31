using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    public interface IBingoConsoleService
    {
        void GenerateOutput(int calledNumber, List<BingoPlayer> players);
        void GenerateBingoOutput(BingoPlayer player, int[] winningNumbers);
    }
}
