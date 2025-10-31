using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan.BlackJack
{
    public class Deck : IDeck
    {
        public List<Card?> Cards { get; set; }
        private readonly IRandomNumberGenerator _random;

        public Deck(IRandomNumberGenerator random)
        {
            _random = random;
            Cards = new List<Card?>();
            Initialize();
        }

        private void Initialize()
        {
            Cards.Clear();

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
                    Cards.Add(new Card(t, ranks[j], values[j]));
        }

        public void Shuffle()
        {
            for (int i = Cards.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (Cards[i], Cards[j]) = (Cards[j], Cards[i]);
            }
        }

        public Card? Draw()
        {
            if (Cards.Count == 0) return null;
            var card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }
    }
}
