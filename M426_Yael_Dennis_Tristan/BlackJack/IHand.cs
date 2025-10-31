namespace M426_Yael_Dennis_Tristan.BlackJack
{
    public interface IHand
    {
        List<Card> Cards { get; }
        void AddCard(Card card);
        int GetValue();
        void Clear();
    }
}
