using M426_Yael_Dennis_Tristan.Players;
using M426_Yael_Dennis_Tristan.BlackJack;

namespace M426_Yael_Dennis_Tristan
{
    public class GameResult
    {
        public List<APlayer> Winners { get; set; } = new();

        /// <summary>
        /// Detaillierte Ergebnisse pro Spieler für BlackJack-Spiele.
        /// Nur für BlackJack relevant, für andere Spiele bleibt dieses Dictionary leer.
        /// </summary>
        public Dictionary<APlayer, BlackJackPlayerResult> PlayerResults { get; set; } = new();
    }
}
