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
            var games = new Dictionary<int, string>()
            {
                {1, "BlackJack" },
                {2, "Bingo" },
                {3, "Leave Casino" }
            };

            _casinoConsoleService.AskForName();
            string playerName = _inputService.GetUserInput();

            while (true)
            {
                _casinoConsoleService.RenderMainMenu(games);
                string selectedGame = _inputService.GetUserInput();

                if (int.TryParse(selectedGame, out int gameNumber))
                {
                    if (gameNumber == 3) return;

                    IGame? game = _gameFactory.CreateGame(gameNumber, playerName);

                    if (game != null)
                    {
                        var players = game.Players;

                        _currencyConsoleService.AskForBet();
                        var betInput = _inputService.GetUserInputAsInt();
                        foreach (var player in players)
                        {
                            player.GetBets(player, betInput);
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
}
