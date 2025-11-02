using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    /// <inheritdoc/>
    public class InputService : IInputService
    {
        /// <inheritdoc/>
        public List<PlayerTemplate> GetPlayerTemplates(string playerName)
        {
            var templates = new List<PlayerTemplate>
            {
                new PlayerTemplate(playerName, PlayerType.Human)
            };

            Console.Write("Wie viele Gegner? (0-3): ");
            if (int.TryParse(Console.ReadLine(), out int robotCount))
            {
                robotCount = Math.Clamp(robotCount, 0, 3);

                for (int i = 0; i < robotCount; i++)
                {
                    templates.Add(new PlayerTemplate($"Roboter {i + 1}", PlayerType.Robot));
                }
            }

            return templates;
        }

        /// <inheritdoc/>
        public string GetHitOrStandDecision(string playerName)
        {
            Console.Write($"{playerName}, Hit or Stand? (h/s): ");
            return Console.ReadLine()?.ToLower() ?? "s";
        }

        /// <inheritdoc/>
        public string GetUserInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }
        
        public int GetUserInputAsInt()
        {
            string input = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(input, out int value))
            {
                return value;
            }

            throw new FormatException($"Ungültige Eingabe: '{input}' ist keine gültige Zahl.");
        }
    }
}
