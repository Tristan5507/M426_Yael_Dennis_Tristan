namespace M426_Yael_Dennis_Tristan.BlackJack
{
    /// <inheritdoc/>
    public class BlackJackDealer : IBlackJackDealer
    {
        private readonly IDeck _deck;
        private readonly IHand _hand;

        public BlackJackDealer(IDeck deck, IHand hand)
        {
            _deck = deck;
            _hand = hand;
        }

        /// <inheritdoc/>
        public Card? DealCard()
        {
            var card = _deck.Draw();
            if (card != null)
            {
                _hand.AddCard(card);
            }
            return card;
        }

        /// <inheritdoc/>
        public void Shuffle()
        {
            _deck.Shuffle();
        }

        /// <inheritdoc/>
        public int GetHandValue()
        {
            return _hand.GetValue();
        }

        /// <inheritdoc/>
        public void ClearHand()
        {
            _hand.Clear();
        }

        /// <inheritdoc/>
        public Card? DrawCard()
        {
            return _deck.Draw();
        }

        /// <inheritdoc/>
        public Card GetFirstCard()
        {
            return _hand.GetFirstCard();
        }

        /// <inheritdoc/>
        public List<Card> GetCards()
        {
            return _hand.GetCards();
        }
    }
}
