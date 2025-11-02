using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.Bingo
{
    /// <inheritdoc/>
    public class BingoGame : IGame
    {
        private readonly List<BingoPlayer> _players;
        private readonly INumberCaller _numberCaller;
        private readonly IBingoConsoleService _consoleService;
         
        public BingoGame(List<BingoPlayer> players, INumberCaller numberCaller, IBingoConsoleService consoleService)
        {
            _players = players;
            _numberCaller = numberCaller;
            _consoleService = consoleService;
        }

        /// <inheritdoc/>
        public GameResult Play()
        {
            Console.CursorVisible = false;
            while (true)
            {
                int calledNumber = _numberCaller.CallNext();
                if (calledNumber == -1)
                {
                    Console.WriteLine("No more numbers!");
                    break;
                }

                foreach (var player in _players)
                {
                    player.MarkNumber(calledNumber);
                }

                _consoleService.GenerateOutput(_players, calledNumber);

                Thread.Sleep(1250);

                foreach (var player in _players)
                {
                    if (player.HasBingo())
                    {
                        int[] winningNumbers = player.GetWinningNumbers();
                        _consoleService.GenerateBingoOutput(player, winningNumbers);
                        return new GameResult { Winner = player };
                    }
                }
            }

            return new GameResult { Winner = null };
        }
    }
}
