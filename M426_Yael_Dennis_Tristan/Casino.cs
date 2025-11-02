using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Factories;

namespace M426_Yael_Dennis_Tristan
{
    public class Casino
    {
        private readonly ICasinoConsoleService _casinoConsoleService;
        private readonly IBlackJackConsoleService _blackJackConsoleService;
        private readonly IGameFactory _gameFactory;
        private readonly IInputService _inputService;

        public Casino(ICasinoConsoleService casinoConsoleService, IBlackJackConsoleService blackJackConsoleService,
                      IGameFactory gameFactory, IInputService inputService)
        {
            _casinoConsoleService = casinoConsoleService;
            _blackJackConsoleService = blackJackConsoleService;
            _gameFactory = gameFactory;
            _inputService = inputService;
        }

        public void Play()
        {
            var games = new Dictionary<int, string>()
            {
                {1, "BlackJack" },
                {2, "Bingo" }
            };

            _casinoConsoleService.RenderMainMenu(games);

            string input = _inputService.GetUserInput();

            if (int.TryParse(input, out int gameNumber))
            {
                IGame? game = _gameFactory.CreateGame(gameNumber);

                if (game != null)
                {
                    _casinoConsoleService.RenderSeparator();
                    var result = game.Play();
                    _casinoConsoleService.RenderOverallWinner(result.Winner);
                }
                else
                {
                    _casinoConsoleService.RenderInvalidSelection();
                }
            }
            else
            {
                _casinoConsoleService.RenderInvalidSelection();
            }
        }
    }
}
