using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    public class InputService : IInputService
    {
        public List<PlayerTemplate> GetPlayerTemplates()
        {
            var templates = new List<PlayerTemplate>();

            Console.Write("Enter your name: ");
            string humanName = Console.ReadLine() ?? "Player";
            templates.Add(new PlayerTemplate(humanName, PlayerType.Human));

            Console.Write("How many robot players? (0-3): ");
            if (int.TryParse(Console.ReadLine(), out int robotCount))
            {
                robotCount = Math.Clamp(robotCount, 0, 3);

                for (int i = 0; i < robotCount; i++)
                {
                    templates.Add(new PlayerTemplate($"Robot {i + 1}", PlayerType.Robot));
                }
            }

            return templates;
        }

        public string GetHitOrStandDecision(string playerName)
        {
            Console.Write($"{playerName}, Hit or Stand? (h/s): ");
            return Console.ReadLine()?.ToLower() ?? "s";
        }

        public string GetGameSelection()
        {
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
