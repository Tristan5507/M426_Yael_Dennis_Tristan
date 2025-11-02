using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan_Test.Mocks;

namespace M426_Yael_Dennis_Tristan_Test.BlackJack
{
    [TestFixture]
    public class BlackJackDealerTests : BlackJackTestBase
    {
        [Test]
        public void DealCard_ZiehtVomDeck()
        {
            var mockDeck = new MockDeck();
            var mockHand = new MockHand();
            var karte = CreateAss();
            mockDeck.KarteZumZurueckgeben = karte;
            var dealer = new BlackJackDealer(mockDeck, mockHand);

            dealer.DealCard();

            Assert.That(mockDeck.DrawWurdeAufgerufen, Is.True);
        }

        [Test]
        public void DealCard_FuegtZurHandHinzu()
        {
            var mockDeck = new MockDeck();
            var mockHand = new MockHand();
            var karte = CreateAss();
            mockDeck.KarteZumZurueckgeben = karte;
            var dealer = new BlackJackDealer(mockDeck, mockHand);

            dealer.DealCard();

            Assert.That(mockHand.AddCardWurdeAufgerufen, Is.True);
            Assert.That(mockHand.HinzugefuegteKarte, Is.EqualTo(karte));
        }

        [Test]
        public void DealCard_GibtKarteZurueck()
        {
            var mockDeck = new MockDeck();
            var mockHand = new MockHand();
            var karte = CreateAss();
            mockDeck.KarteZumZurueckgeben = karte;
            var dealer = new BlackJackDealer(mockDeck, mockHand);

            var ergebnis = dealer.DealCard();

            Assert.That(ergebnis, Is.EqualTo(karte));
        }

        [Test]
        public void DealCard_DeckGibtNull_FuegtNichtZurHandHinzu()
        {
            var mockDeck = new MockDeck();
            var mockHand = new MockHand();
            mockDeck.KarteZumZurueckgeben = null;
            var dealer = new BlackJackDealer(mockDeck, mockHand);

            dealer.DealCard();

            Assert.That(mockHand.AddCardWurdeAufgerufen, Is.False);
        }

        [Test]
        public void DrawCard_ZiehtVomDeck()
        {
            var mockDeck = new MockDeck();
            var mockHand = new MockHand();
            var karte = CreateKoenig();
            mockDeck.KarteZumZurueckgeben = karte;
            var dealer = new BlackJackDealer(mockDeck, mockHand);

            dealer.DrawCard();

            Assert.That(mockDeck.DrawWurdeAufgerufen, Is.True);
        }

        [Test]
        public void DrawCard_FuegtNICHTZurHandHinzu()
        {
            var mockDeck = new MockDeck();
            var mockHand = new MockHand();
            var karte = CreateKoenig();
            mockDeck.KarteZumZurueckgeben = karte;
            var dealer = new BlackJackDealer(mockDeck, mockHand);

            dealer.DrawCard();

            Assert.That(mockHand.AddCardWurdeAufgerufen, Is.False);
        }

        [Test]
        public void Shuffle_RuftDeckShuffleAuf()
        {
            var mockDeck = new MockDeck();
            var mockHand = new MockHand();
            var dealer = new BlackJackDealer(mockDeck, mockHand);

            dealer.Shuffle();

            Assert.That(mockDeck.ShuffleWurdeAufgerufen, Is.True);
        }

        [Test]
        public void GetHandValue_RuftHandGetValueAuf()
        {
            var mockDeck = new MockDeck();
            var mockHand = new MockHand();
            mockHand.WertZumZurueckgeben = 21;
            var dealer = new BlackJackDealer(mockDeck, mockHand);

            var wert = dealer.GetHandValue();

            Assert.That(mockHand.GetValueWurdeAufgerufen, Is.True);
            Assert.That(wert, Is.EqualTo(21));
        }

        [Test]
        public void ClearHand_RuftHandClearAuf()
        {
            var mockDeck = new MockDeck();
            var mockHand = new MockHand();
            var dealer = new BlackJackDealer(mockDeck, mockHand);

            dealer.ClearHand();

            Assert.That(mockHand.ClearWurdeAufgerufen, Is.True);
        }

        [Test]
        public void GetFirstCard_RuftHandGetFirstCardAuf()
        {
            var mockDeck = new MockDeck();
            var mockHand = new MockHand();
            var karte = CreateAss();
            mockHand.ErsteKarteZumZurueckgeben = karte;
            var dealer = new BlackJackDealer(mockDeck, mockHand);

            var ersteKarte = dealer.GetFirstCard();

            Assert.That(mockHand.GetFirstCardWurdeAufgerufen, Is.True);
            Assert.That(ersteKarte, Is.EqualTo(karte));
        }

        [Test]
        public void GetCards_RuftHandGetCardsAuf()
        {
            var mockDeck = new MockDeck();
            var mockHand = new MockHand();
            var karten = new List<Card> { CreateAss(), CreateKoenig() };
            mockHand.KartenZumZurueckgeben = karten;
            var dealer = new BlackJackDealer(mockDeck, mockHand);

            var ergebnis = dealer.GetCards();

            Assert.That(mockHand.GetCardsWurdeAufgerufen, Is.True);
            Assert.That(ergebnis, Is.EqualTo(karten));
        }
    }
}
