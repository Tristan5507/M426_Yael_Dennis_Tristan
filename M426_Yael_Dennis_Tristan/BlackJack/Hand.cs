namespace M426_Yael_Dennis_Tristan.BlackJack
{
    public class Hand : IHand
    {
        public List<Card> Cards { get; set; }

        public Hand()
        {
            Cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            if (card != null)
            {
                Cards.Add(card);
            }
        }

        public int GetValue()
        {
            int value = 0;
            int aces = 0;

            foreach (var card in Cards)
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

        public void Clear()
        {
            Cards.Clear();
        }
    }
}
