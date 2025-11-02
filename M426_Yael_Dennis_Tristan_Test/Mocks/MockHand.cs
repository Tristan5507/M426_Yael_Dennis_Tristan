using M426_Yael_Dennis_Tristan.BlackJack;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockHand : IHand
    {
        public bool AddCardWurdeAufgerufen { get; private set; }
        public bool ClearWurdeAufgerufen { get; private set; }
        public bool GetValueWurdeAufgerufen { get; private set; }
        public bool GetFirstCardWurdeAufgerufen { get; private set; }
        public bool GetCardsWurdeAufgerufen { get; private set; }

        public Card? HinzugefuegteKarte { get; private set; }
        public int WertZumZurueckgeben { get; set; }
        public Card? ErsteKarteZumZurueckgeben { get; set; }
        public List<Card> KartenZumZurueckgeben { get; set; } = new List<Card>();

        public void AddCard(Card? card)
        {
            AddCardWurdeAufgerufen = true;
            HinzugefuegteKarte = card;
        }

        public void Clear()
        {
            ClearWurdeAufgerufen = true;
        }

        public List<Card> GetCards()
        {
            GetCardsWurdeAufgerufen = true;
            return KartenZumZurueckgeben;
        }

        public Card GetFirstCard()
        {
            GetFirstCardWurdeAufgerufen = true;
            return ErsteKarteZumZurueckgeben!;
        }

        public int GetValue()
        {
            GetValueWurdeAufgerufen = true;
            return WertZumZurueckgeben;
        }
    }
}
