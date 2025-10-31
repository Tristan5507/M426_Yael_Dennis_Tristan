namespace M426_Yael_Dennis_Tristan.BlackJack
{
    public interface IBlackJackDealer
    {
        IDeck Deck { get; }
        IHand Hand { get; }
        void DealCard();
        void Shuffle();
        int GetHandValue();
        void ClearHand();
    }
}
