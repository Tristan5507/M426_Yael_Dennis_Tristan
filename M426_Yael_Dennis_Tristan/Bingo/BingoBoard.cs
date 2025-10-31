using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan.Bingo
{
    public class BingoBoard : IBingoBoard
    {
        private const int Size = 5;

        public BingoField[,] Fields { get; }

        public BingoBoard(IRandomNumberGenerator random)
        {
            Fields = GenerateBoard(random);
        }

        private BingoField[,] GenerateBoard(IRandomNumberGenerator random)
        {
            var nums = Enumerable.Range(1, 75).OrderBy(_ => random.Next()).Take(Size * Size).ToArray();
            var board = new BingoField[Size, Size];
            int index = 0;
            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                    board[r, c] = new BingoField(nums[index++]);
            return board;
        }

        public void MarkNumber(int number)
        {
            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                    if (Fields[r, c].Number == number)
                        Fields[r, c].Checked = true;
        }

        public bool HasBingo()
        {
            // Check rows
            for (int r = 0; r < Size; r++)
            {
                if (Enumerable.Range(0, Size).All(c => Fields[r, c].Checked))
                    return true;
            }

            // Check columns
            for (int c = 0; c < Size; c++)
            {
                if (Enumerable.Range(0, Size).All(r => Fields[r, c].Checked))
                    return true;
            }

            // Check diagonals
            if (Enumerable.Range(0, Size).All(i => Fields[i, i].Checked))
                return true;
            if (Enumerable.Range(0, Size).All(i => Fields[i, Size - 1 - i].Checked))
                return true;

            return false;
        }
    }
}
