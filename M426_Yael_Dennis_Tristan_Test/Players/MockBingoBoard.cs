using M426_Yael_Dennis_Tristan.Bingo;

namespace M426_Yael_Dennis_Tristan_Test.Players
{
public class MockBingoBoard : IBingoBoard
{
    public bool MarkNumberCalled { get; private set; }
    public int LastMarkedNumber { get; private set; }
    public bool HasBingoReturn { get; set; }
    public int[] WinningNumbersReturn { get; set; } = new int[0];
    public BingoField[,] FieldsReturn { get; set; } = new BingoField[0,0];

    public void MarkNumber(int number)
    {
        MarkNumberCalled = true;
        LastMarkedNumber = number;
    }

    public bool HasBingo() => HasBingoReturn;

    public int[] GetWinningNumbers() => WinningNumbersReturn;

    public BingoField[,] Fields => FieldsReturn;
}
}