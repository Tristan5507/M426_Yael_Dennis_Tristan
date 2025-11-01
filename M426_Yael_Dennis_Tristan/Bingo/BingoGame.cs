using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;
namespace M426_Yael_Dennis_Tristan.Bingo
{
    /// <inheritdoc/>
    public class BingoGame : IGame
    {
        public List<APlayer> Players { get; }
        private readonly List<BingoPlayer> _players;
        private readonly INumberCaller _numberCaller;
        private readonly IBingoConsoleService _consoleService;

        public BingoGame(List<BingoPlayer> players, INumberCaller numberCaller, IBingoConsoleService consoleService)
        {
            _players = players;
            Players = players.Cast<APlayer>().ToList();
            _numberCaller = numberCaller;
            _consoleService = consoleService;
        }

        /// <inheritdoc/>
        public GameResult Play()
        {
            Console.CursorVisible = false;
            var result = new GameResult();

            while (true)
            {
                int calledNumber = _numberCaller.CallNext();
                if (calledNumber == -1)
                {
                    Console.WriteLine("Keine weiteren Zahlen!");
                    break;
                }

                foreach (var player in _players)
                {
                    player.MarkNumber(calledNumber);
                }

                _consoleService.GenerateOutput(_players, calledNumber);

                Thread.Sleep(1250);
                
                var currentWinners = _players.Where(p => p.HasBingo()).ToList();

                if (currentWinners.Any())
                {
                    foreach (var winner in currentWinners)
                    {
                        int[] winningNumbers = winner.GetWinningNumbers();
                        _consoleService.GenerateBingoOutput(winner, winningNumbers);
                        result.Winners.Add(winner);
                    }

                    break;
                }
            }

            return result;
        }
    }
}
