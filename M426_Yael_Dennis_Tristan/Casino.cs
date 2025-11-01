using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Currency;
using M426_Yael_Dennis_Tristan.Factories;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan
{
    public class Casino
    {
        private readonly ICasinoConsoleService _casinoConsoleService;
        private readonly IBlackJackConsoleService _blackJackConsoleService;
        private readonly IGameFactory _gameFactory;
        private readonly IInputService _inputService;
        private readonly ICurrencyConsoleService _currencyConsoleService;

        public Casino(ICasinoConsoleService casinoConsoleService, IBlackJackConsoleService blackJackConsoleService,
                      IGameFactory gameFactory, IInputService inputService, ICurrencyConsoleService currencyConsoleService)
        {
            _casinoConsoleService = casinoConsoleService;
            _blackJackConsoleService = blackJackConsoleService;
            _gameFactory = gameFactory;
            _inputService = inputService;
            _currencyConsoleService = currencyConsoleService;
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
                    var players = game.Players;
                    
                    _currencyConsoleService.RenderBalances(players);
                    
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
