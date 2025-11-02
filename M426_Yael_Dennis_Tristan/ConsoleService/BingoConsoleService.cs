using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    /// <inheritdoc/>
    public class BingoConsoleService : IBingoConsoleService
    {
        private const int BoardWidth = 27;
        private const int BoardHeight = 8;

        /// <inheritdoc/>
        public void GenerateOutput(List<BingoPlayer> players, int calledNumber)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Number called: {calledNumber}");
            Console.ResetColor();
            Console.WriteLine();

            int columns = 2;
            for (int i = 0; i < players.Count; i++)
            {
                int row = i / columns;
                int col = i % columns;

                int topOffset = 3 + row * BoardHeight;
                int leftOffset = col * BoardWidth;

                DrawBoard(players[i], calledNumber, topOffset, leftOffset);
            }
        }

        private void DrawBoard(BingoPlayer player, int calledNumber, int offsetTop, int offsetLeft, int[]? winningNumbers = null)
        {
            Console.SetCursorPosition(offsetLeft, offsetTop);
            Console.WriteLine($"{player.Name}'s Board:");

            var fields = player.GetFields();
            int size = fields.GetLength(0);

            for (int r = 0; r < size; r++)
            {
                Console.SetCursorPosition(offsetLeft, offsetTop + 1 + r);
                for (int c = 0; c < size; c++)
                {
                    int number = fields[r, c].Number;
                    if (fields[r, c].Checked)
                    {
                        if (number == calledNumber)
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else if (winningNumbers != null && winningNumbers.Contains(number))
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    Console.Write($"{number,3} ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        /// <inheritdoc/>s
        public void GenerateBingoOutput(List<BingoPlayer> winners)
        {
            Console.Clear();
            int columns = 2;
            for (int i = 0; i < winners.Count; i++)
            {
                int row = i / columns;
                int col = i % columns;

                int topOffset = 3 + row * BoardHeight;
                int leftOffset = col * BoardWidth;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"BINGO! {winners[i].Name} wins!");
                Console.ResetColor();
                Console.WriteLine();
                DrawBoard(winners[i], -1, topOffset, leftOffset, winners[i].GetWinningNumbers());
            }

            Console.WriteLine("Möchten Sie nochmals spielen? [yes/no] ");
        }
    }
}
