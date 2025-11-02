using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    /// <inheritdoc/>
    public class InputService : IInputService
    {
        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public string GetHitOrStandDecision(string playerName)
        {
            while (true)
            {
                Console.Write($"{playerName}, Hit or Stand? (h/s): ");
                string input = Console.ReadLine()?.ToLower().Trim() ?? "";

                if (input == "h" || input == "s")
                {
                    return input;
                }

                Console.WriteLine("Ungültige Eingabe! Bitte 'h' für Hit oder 's' für Stand eingeben.");
            }
        }

        /// <inheritdoc/>
        public string GetUserInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
