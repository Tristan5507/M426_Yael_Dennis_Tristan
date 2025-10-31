using M426_Yael_Dennis_Tristan.Bingo;
using M426_Yael_Dennis_Tristan.Players;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace M426_Yael_Dennis_Tristan
{
    public class Casino
    {
        private readonly IHost _host;

        public Dictionary<int, Type> Games { get; } = new Dictionary<int, Type>()
        {
            {1, typeof(BingoGame) }
        };

        public Casino(IHost host)
        {
            _host = host;
        }

        public void Play()
        {
            var players = new List<PlayerTemplate>()
            {
                new PlayerTemplate("Alice", PlayerType.Human),
                new PlayerTemplate("Bob", PlayerType.Robot),
                new PlayerTemplate("Charlie", PlayerType.Robot)
            };
            string input = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(input, out int gameNumber) &&
                Games.TryGetValue(gameNumber, out Type? type))
            {
                var game = (IGame)ActivatorUtilities.CreateInstance(_host.Services, type, players);
                //var constructor = type.GetConstructors().FirstOrDefault(c => c.GetParameters().Length == 2);
                //var invoked = constructor?.Invoke([players, _host]);
                //if (invoked is IGame game)
                //{
                    game.Play();
                //}
            }
            else

            {
                Console.WriteLine("Invalid game selection.");
            }
        }
    }
}
