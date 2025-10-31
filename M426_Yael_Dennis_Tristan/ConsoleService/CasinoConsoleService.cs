namespace M426_Yael_Dennis_Tristan.ConsoleService
{
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

        public void RenderMainMenu(Dictionary<int, string> games)
        {
            Console.Clear();
            Console.WriteLine(_logo);

            Console.WriteLine("Verfügbare Spiele:");
            Console.WriteLine();

            foreach (var game in games)
            {
                Console.Write($"  [{game.Key}] ");
                Console.WriteLine($"{game.Value}");
            }

            Console.WriteLine();
            Console.Write("Wähle ein Spiel (Nummer eingeben): ");
        }

        public void RenderInvalidSelection()
        {
            Console.WriteLine("\nUngültige Auswahl. Bitte versuche es erneut.");
            Console.WriteLine("\nDrücke eine beliebige Taste...");
            Console.ReadKey(true);
        }

        public void RenderSeparator()
        {
            Console.WriteLine();
            Console.WriteLine("════════════════════════════════════");
            Console.WriteLine();
        }
    }
}
