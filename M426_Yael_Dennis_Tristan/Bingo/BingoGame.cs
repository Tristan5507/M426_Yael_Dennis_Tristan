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

        /// <inheritdoc/>
        public IEnumerable<APlayer> Players => _players.Cast<APlayer>();

        public BingoGame(List<BingoPlayer> players, INumberCaller numberCaller, IBingoConsoleService consoleService)
        {
            _players = players;
            _numberCaller = numberCaller;
            _consoleService = consoleService;
        }

        /// <inheritdoc/>
        public GameResult Play()
        {
            _consoleService.SetCursorInvisible();
            var result = new GameResult();

            while (true)
            {
                int calledNumber = _numberCaller.CallNext();
                if (calledNumber == -1)
                {
                    _consoleService.WriteOutput("Keine weiteren Zahlen!");
                    break;
                }

                foreach (var player in _players)
                {
                    player.MarkNumber(calledNumber);
                }

                _consoleService.GenerateOutput(_players, calledNumber);

                Thread.Sleep(1250);

                var winners = _players.Where(p => p.HasBingo()).ToList();
                if (winners.Count != 0)
                {
                    _consoleService.GenerateBingoOutput(winners);
                    result.Winners.AddRange(winners);
                    break;
                }
            }

            return result;
        }
    }
}
