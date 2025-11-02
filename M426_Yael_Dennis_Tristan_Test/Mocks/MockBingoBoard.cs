using M426_Yael_Dennis_Tristan.Bingo;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockBingoBoard : IBingoBoard
    {
        private readonly int _requiredNumber;
        public bool RequiredNumberCalled { get; private set; }

        public BingoField[,] Fields => throw new NotImplementedException();

        public MockBingoBoard(int requiredNumber)
        {
            _requiredNumber = requiredNumber;
        }

        public int[] GetWinningNumbers()
        {
            if (RequiredNumberCalled)
            {
                return [_requiredNumber];
            }

            return [];
        }

        public bool HasBingo()
        {
            return RequiredNumberCalled;
        }

        public void MarkNumber(int number)
        {
            if (number == _requiredNumber)
            {
                RequiredNumberCalled = true;
            }
        }
    }
}
