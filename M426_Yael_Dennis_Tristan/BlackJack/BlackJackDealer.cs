namespace M426_Yael_Dennis_Tristan.BlackJack
{
    public class BlackJackDealer : IBlackJackDealer
    {
        public IDeck Deck { get; set; }
        public IHand Hand { get; set; }

        public BlackJackDealer(IDeck deck, IHand hand)
        {
            Deck = deck;
            Hand = hand;
        }

        public void DealCard()
        {
            var card = Deck.Draw();
            if (card != null)
            {
                Hand.AddCard(card);
            }
        }

        public void Shuffle()
        {
            Deck.Shuffle();
        }

        public int GetHandValue()
        {
            return Hand.GetValue();
        }

        public void ClearHand()
        {
            Hand.Clear();
        }
    }
}
