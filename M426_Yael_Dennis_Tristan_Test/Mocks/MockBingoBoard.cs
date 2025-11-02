using M426_Yael_Dennis_Tristan.Bingo;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockBingoBoard : IBingoBoard
    {
        public BingoField[,] Fields => throw new NotImplementedException();

        public int[] GetWinningNumbers()
        {
            throw new NotImplementedException();
        }

        public bool HasBingo()
        {
            throw new NotImplementedException();
        }

        public void MarkNumber(int number)
        {
            throw new NotImplementedException();
        }
    }
}
