namespace M426_Yael_Dennis_Tristan.BlackJack
{
    public interface IDeck
    {
        List<Card?> Cards { get; }
        void Shuffle();
        Card? Draw();
    }
}
