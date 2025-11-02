using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    /// <inheritdoc/>
    public class CasinoConsoleService : ICasinoConsoleService
    {
        private readonly string _logo = @"

 $$$$$$\                      $$\
$$  __$$\                     \__|
$$ /  \__| $$$$$$\   $$$$$$$\ $$\ $$$$$$$\   $$$$$$\
$$ |       \____$$\ $$  _____|$$ |$$  __$$\ $$  __$$\
$$ |       $$$$$$$ |\$$$$$$\  $$ |$$ |  $$ |$$ /  $$ |
$$ |  $$\ $$  __$$ | \____$$\ $$ |$$ |  $$ |$$ |  $$ |
\$$$$$$  |\$$$$$$$ |$$$$$$$  |$$ |$$ |  $$ |\$$$$$$  |
 \______/  \_______|\_______/ \__|\__|  \__| \______/

";

        /// <inheritdoc/>
        public void RenderLogo()
        {
            Console.Clear();
            Console.WriteLine(_logo);
        }

        /// <inheritdoc/>
        public void RenderMainMenu(Dictionary<int, string> games)
        {
            Console.Clear();
            Console.WriteLine(_logo);

            Console.WriteLine("Verfügbare Spiele:");
            Console.WriteLine();

            foreach (var game in games)
            {
                Console.Write($"  [{game.Key}] ");
                Console.WriteLine(game.Value);
            }

            Console.WriteLine();
        }

        /// <inheritdoc/>
        public void RenderOverallWinner(APlayer? winner)
        {
            Console.WriteLine();
            if (winner != null)
            {
                Console.WriteLine($"*** Overall winner: {winner.Name} ***");
            }
            else
            {
                Console.WriteLine("*** No clear winner ***");
            }
        }

        /// <inheritdoc/>
        public void RenderInvalidSelection()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ungültige Eingabe, bitte versuchen Sie es erneut.");
            Console.ResetColor();
        }

        /// <inheritdoc/>
        public void RenderSeparator()
        {
            Console.WriteLine();
            Console.WriteLine("════════════════════════════════════");
            Console.WriteLine();
        }
    }
}
