namespace M426_Yael_Dennis_Tristan.BlackJack
{
    /// <summary>
    /// Repraesentiert das Ergebnis eines einzelnen Spielers in einer BlackJack-Runde.
    /// </summary>
    public enum BlackJackPlayerResult
    {
        /// <summary>
        /// Spieler hat ueberkauft (über 21).
        /// </summary>
        Bust,

        /// <summary>
        /// Spieler hat gewonnen.
        /// </summary>
        Win,

        /// <summary>
        /// Spieler hat verloren.
        /// </summary>
        Lose,

        /// <summary>
        /// Unentschieden mit dem Dealer.
        /// </summary>
        Push
    }
}
