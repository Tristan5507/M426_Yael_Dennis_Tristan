using M426_Yael_Dennis_Tristan.BlackJack;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockBlackJackDealer : IBlackJackDealer
    {
        public bool ShuffleWurdeAufgerufen { get; private set; }
        public bool ClearHandWurdeAufgerufen { get; private set; }
        public bool DealCardWurdeAufgerufen { get; private set; }
        public bool DrawCardWurdeAufgerufen { get; private set; }
        public int DealCardAufrufe { get; private set; }
        public int DrawCardAufrufe { get; private set; }

        public int HandWert { get; set; }
        public Card? KarteZumZurueckgeben { get; set; }

        public void ClearHand()
        {
            ClearHandWurdeAufgerufen = true;
        }

        public Card? DealCard()
        {
            DealCardWurdeAufgerufen = true;
            DealCardAufrufe++;
            return KarteZumZurueckgeben;
        }

        public Card? DrawCard()
        {
            DrawCardWurdeAufgerufen = true;
            DrawCardAufrufe++;
            return KarteZumZurueckgeben;
        }

        public List<Card> GetCards()
        {
            throw new NotImplementedException();
        }

        public Card GetFirstCard()
        {
            return KarteZumZurueckgeben!;
        }

        public List<Card> GetCards()
        {
            return new List<Card>();
        }

        public int GetHandValue()
        {
            return HandWert;
        }

        public void Shuffle()
        {
            ShuffleWurdeAufgerufen = true;
        }
    }
}
