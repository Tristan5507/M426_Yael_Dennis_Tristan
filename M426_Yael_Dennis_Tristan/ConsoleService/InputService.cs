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
            if (int.TryParse(Console.ReadLine(), out int robotCount) && robotCount >= 0 && robotCount <= 3)
            {
                for (int i = 0; i < robotCount; i++)
                {
                    templates.Add(new PlayerTemplate($"Roboter {i + 1}", PlayerType.Robot));
                }

                return templates;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ungültige Eingabe. Bitte eine Zahl zwischen 0 und 3 eingeben.");
            Console.ResetColor();

            return GetPlayerTemplates(playerName);
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
        public string GetUserInput(string? message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.Write(message);
            }

            return Console.ReadLine() ?? string.Empty;
        }

        /// <inheritdoc/>
        public int GetUserInputAsInt(string? message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.Write(message);
            }

            string input = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ungültige Eingabe: '{input}' ist keine gültige Zahl.");
            Console.ResetColor();

            return GetUserInputAsInt(message);
        }

        /// <inheritdoc/>
        public bool GetUserInputAsBool(string? message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.Write(message);
            }

            string input = Console.ReadLine() ?? string.Empty;
            input = input.Trim();
            if (input.Equals("y", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("yes", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("j", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("ja", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (input.Equals("n", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("no", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("nein", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ungültige Eingabe: '{input}' ist keine gültige Ja/Nein-Antwort.");
            Console.ResetColor();

            return GetUserInputAsBool(message);
        }
    }
}
