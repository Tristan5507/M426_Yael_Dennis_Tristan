namespace M426_Yael_Dennis_Tristan.BlackJack
{
    /// <inheritdoc/>
    public class Hand : IHand
    {
        private readonly List<Card> _cards = new();

        /// <inheritdoc/>
        public void AddCard(Card? card)
        {
            if (card != null)
            {
                _cards.Add(card);
            }
        }

        /// <inheritdoc/>
        public int GetValue()
        {
            int value = 0;
            int aces = 0;

            foreach (var card in _cards)
            {
                value += card.Value;
                if (card.Rank == "Ass") aces++;
            }

            while (value > 21 && aces > 0)
            {
                value -= 10;
                aces--;
            }

            return value;
        }

        /// <inheritdoc/>
        public Card GetFirstCard()
        {
            return _cards.First();
        }

        /// <inheritdoc/>
        public void Clear()
        {
            _cards.Clear();
        }

        /// <inheritdoc/>
        public List<Card> GetCards()
        {
            return new List<Card>(_cards);
        }
    }
}
