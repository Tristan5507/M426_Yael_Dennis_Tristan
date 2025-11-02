using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Factories;

namespace M426_Yael_Dennis_Tristan
{
    public class Casino
    {
        private readonly ICasinoConsoleService _casinoConsoleService;
        private readonly IGameFactory _gameFactory;
        private readonly IInputService _inputService;
        private readonly ICurrencyConsoleService _currencyConsoleService;
        private readonly Dictionary<int, string> _games = new Dictionary<int, string>()
        {
            {1, "BlackJack" },
            {2, "Bingo" }
        };

    public Casino(ICasinoConsoleService casinoConsoleService, IGameFactory gameFactory,
                  IInputService inputService, ICurrencyConsoleService currencyConsoleService)
        {
            _casinoConsoleService = casinoConsoleService;
            _gameFactory = gameFactory;
            _inputService = inputService;
            _currencyConsoleService = currencyConsoleService;
        }

        public void Play()
        {
            bool playAgain;

            _casinoConsoleService.RenderLogo();
            string playerName = _inputService.GetUserInput("Willkommen! Bitte geben Sie Ihren Namen ein: ");

            do
            {
                _casinoConsoleService.RenderMainMenu(_games);
                IGame game = GetGame(playerName);

                var players = game.Players;
                foreach (var player in players)
                {
                    player.PlaceBet();
                }

                _currencyConsoleService.RenderBetConfirmation(players);
                _casinoConsoleService.RenderSeparator();

                var result = game.Play();

                foreach (var winner in result.Winners)
                {
                    winner.Win();
                    _currencyConsoleService.RenderWinner(winner);
                }

                var losers = game.Players.Except(result.Winners).ToList();
                foreach (var loser in losers)
                {
                    loser.Lose();
                    _currencyConsoleService.RenderLoser(loser);
                }

                _currencyConsoleService.RenderBalances(players);

                playAgain = _inputService.GetUserInputAsBool("Möchten Sie ein weiters Spiel spielen? [yes/no] ");
            }
            while (playAgain);


            Console.WriteLine("Danke für's spielen!");
        }

        private IGame GetGame(string playerName)
        {
            int selectedGame = _inputService.GetUserInputAsInt("Wähle ein Spiel (Nummer eingeben): ");

            IGame? game = _gameFactory.CreateGame(selectedGame, playerName);
            if (game == null)
            {
                _casinoConsoleService.RenderInvalidSelection();
                return GetGame(playerName);
            }

            return game;
        }
    }
}
