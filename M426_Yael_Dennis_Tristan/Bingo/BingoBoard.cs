namespace M426_Yael_Dennis_Tristan.Bingo
{
    public class BingoBoard
    {
        private const int Size = 5;
        private readonly List<int> _winningNumbers = new ();

        public BingoField[,] Fields { get; }

        public BingoBoard()
        {
            Fields = GenerateBoard();
        }

        private static BingoField[,] GenerateBoard()
        {
            var rand = new Random();
            var nums = Enumerable.Range(1, 75).OrderBy(_ => rand.Next()).Take(Size * Size).ToArray();
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

        public int[] GetWinningNumbers()
        {
            return _winningNumbers.ToArray();
        }
    }
}
