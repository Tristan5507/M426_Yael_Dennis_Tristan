using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.Bingo
{
    public class BingoGame : IGame
    {
        private readonly INumberCaller _numberCaller;
        private readonly IBingoConsoleService _consoleService;
        private List<BingoPlayer> _players = new();

        public BingoGame(List<PlayerTemplate> playerTemplates, INumberCaller numberCaller, IBingoConsoleService consoleService)
        {
            _numberCaller = numberCaller;
            _consoleService = consoleService;
            playerTemplates.ForEach(x => _players.Add(new BingoPlayer(x)));
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
                    player.Board.MarkNumber(calledNumber);
                }

                _consoleService.GenerateOutput(calledNumber, _players);

                foreach (var player in _players)
                {
                    if (player.Board.HasBingo())
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
