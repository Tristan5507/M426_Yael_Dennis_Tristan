using M426_Yael_Dennis_Tristan.BlackJack;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockDeck : IDeck
    {
        public bool DrawWurdeAufgerufen { get; private set; }
        public bool ShuffleWurdeAufgerufen { get; private set; }
        public Card? KarteZumZurueckgeben { get; set; }

        public Card? Draw()
        {
            DrawWurdeAufgerufen = true;
            return KarteZumZurueckgeben;
        }

        public void Shuffle()
        {
            ShuffleWurdeAufgerufen = true;
        }
    }
}
