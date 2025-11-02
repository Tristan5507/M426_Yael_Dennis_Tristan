using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan.Bingo
{
    /// <inheritdoc/>
    public class BingoBoard : IBingoBoard
    {
        private const int Size = 5;
        private readonly List<int> _winningNumbers = new();

        /// <inheritdoc/>
        public BingoField[,] Fields { get; }

        public BingoBoard(IRandom random)
        {
            Fields = GenerateBoard(random);
        }

        private static BingoField[,] GenerateBoard(IRandom random)
        {
            var nums = Enumerable.Range(1, 75).OrderBy(_ => random.Next()).Take(Size * Size).ToArray();
            var board = new BingoField[Size, Size];
            int index = 0;
            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                    board[r, c] = new BingoField(nums[index++]);
            return board;
        }

        /// <inheritdoc/>
        public void MarkNumber(int number)
        {
            for (int r = 0; r < Size; r++)
                for (int c = 0; c < Size; c++)
                    if (Fields[r, c].Number == number)
                        Fields[r, c].Checked = true;
        }

        /// <inheritdoc/>
        public bool HasBingo()
        {
            _winningNumbers.Clear();

            // Check rows
            for (int r = 0; r < Size; r++)
            {
                if (Enumerable.Range(0, Size).All(c => Fields[r, c].Checked))
                {
                    for (int c = 0; c < Size; c++)
                        _winningNumbers.Add(Fields[r, c].Number);
                }
            }

            // Check columns
            for (int c = 0; c < Size; c++)
            {
                if (Enumerable.Range(0, Size).All(r => Fields[r, c].Checked))
                {
                    for (int r = 0; r < Size; r++)
                        _winningNumbers.Add(Fields[r, c].Number);
                }
            }

            // Check diagonals
            if (Enumerable.Range(0, Size).All(i => Fields[i, i].Checked))
            {
                for (int i = 0; i < Size; i++)
                    _winningNumbers.Add(Fields[i, i].Number);
            }
            if (Enumerable.Range(0, Size).All(i => Fields[i, Size - 1 - i].Checked))
            {
                for (int i = 0; i < Size; i++)
                    _winningNumbers.Add(Fields[i, Size - 1 - i].Number);
            }

            return _winningNumbers.Count > 0;
        }

        /// <inheritdoc/>
        public int[] GetWinningNumbers()
        {
            return _winningNumbers.ToArray();
        }
    }
}
