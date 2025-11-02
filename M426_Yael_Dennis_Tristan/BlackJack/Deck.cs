using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan.BlackJack
{
    /// <inheritdoc/>
    public class Deck : IDeck
    {
        private List<Card?> _cards { get; } = new();
        private readonly IRandom _random;

        public Deck(IRandom random)
        {
            _random = random;
            Initialize();
        }

        private void Initialize()
        {
            _cards.Clear();

            // generiert von Chatgpt mit Promt
            // Erstell mir Arrays für  Kartendeck: Farben, Werte, Punkte für Blackjack
            string[] suits = ["Herz", "Karo", "Pik", "Kreuz"];
            string[] ranks =
            [
                "2", "3", "4", "5", "6", "7", "8", "9", "10",
                "Bube", "Dame", "König", "Ass"
            ];

            int[] values = [2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11];

            foreach (var t in suits)
                for (int j = 0; j < ranks.Length; j++)
                    _cards.Add(new Card(t, ranks[j], values[j]));
        }

        
        // Hier wurde Chatgpt verwendet
        // mit der frage wie man am besten arrays mischelt
        /// <inheritdoc/>
        public void Shuffle()
        {
            for (int i = _cards.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
            }
        }

        /// <inheritdoc/>
        public Card? Draw()
        {
            if (_cards.Count == 0) return null;
            var card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }
    }
}
