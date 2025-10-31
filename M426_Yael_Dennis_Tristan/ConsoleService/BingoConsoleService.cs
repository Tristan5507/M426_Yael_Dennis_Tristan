using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    public class BingoConsoleService : IBingoConsoleService
    {
        private const int BoardHeight = 8;

        public void GenerateOutput(int calledNumber, List<BingoPlayer> players)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Number called: {calledNumber}");
            Console.ResetColor();
            Console.WriteLine();

            int offsetTop = 3;
            foreach (var player in players)
            {
                DrawBoard(player, calledNumber, offsetTop);
                offsetTop += BoardHeight;
            }
        }

        private void DrawBoard(BingoPlayer player, int calledNumber, int offsetTop, int[]? winningNumbers = null)
        {
            Console.SetCursorPosition(0, offsetTop);
            Console.WriteLine($"{player.Name}'s Board:");

            var fields = player.Board.Fields;
            int size = fields.GetLength(0);

            for (int r = 0; r < size; r++)
            {
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

        public void GenerateBingoOutput(BingoPlayer winner, int[] winningNumbers)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"BINGO! {winner.Name} wins!");
            Console.ResetColor();
            Console.WriteLine();
            DrawBoard(winner, -1, 1, winningNumbers);
        }
    }
}
