using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.Bingo
{
    public class BingoGame : IGame
    {
        private readonly INumberCaller _numberCaller;
        private readonly List<BingoPlayer> _players;
        private readonly IBingoConsoleService _consoleService;

        public BingoGame(INumberCaller numberCaller, List<BingoPlayer> players, IBingoConsoleService consoleService)
        {
            _numberCaller = numberCaller;
            _players = players;
            _consoleService = consoleService;
        }

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

                _consoleService.GenerateOutput(calledNumber, _players);

                foreach (var player in _players)
                {
                    if (player.HasBingo())
                    {
                        int[] winningNumbers = player.Board.GetWinningNumbers();
                        _consoleService.GenerateBingoOutput(player, winningNumbers);
                        return new GameResult { Winner = player };
                    }
                }

                Thread.Sleep(1000);
            }

            return new GameResult { Winner = null };
        }
    }
}
