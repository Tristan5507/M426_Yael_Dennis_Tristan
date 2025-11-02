using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan_Test.Mocks;

namespace M426_Yael_Dennis_Tristan_Test.BlackJack
{
    [TestFixture]
    public class DeckTests : BlackJackTestBase
    {
        [Test]
        public void Draw_GibtKarteZurueck()
        {
            var mockRandom = new MockRandom([0]);
            var deck = new Deck(mockRandom);

            var karte = deck.Draw();

            Assert.That(karte, Is.Not.Null);
        }

        [Test]
        public void NeuesDeck_52MalDraw_AlleKartenNichtNull()
        {
            var mockRandom = new MockRandom([0]);
            var deck = new Deck(mockRandom);

            for (int i = 0; i < 52; i++)
            {
                var karte = deck.Draw();
                Assert.That(karte, Is.Not.Null, $"Karte {i + 1} sollte nicht null sein");
            }
        }

        [Test]
        public void NeuesDeck_53MalDraw_GibtNull()
        {
            var mockRandom = new MockRandom([0]);
            var deck = new Deck(mockRandom);

            for (int i = 0; i < 52; i++)
            {
                deck.Draw();
            }

            var karte = deck.Draw();

            Assert.That(karte, Is.Null);
        }

        [Test]
        public void LeeresDeck_Draw_GibtNull()
        {
            var mockRandom = new MockRandom([0]);
            var deck = new Deck(mockRandom);

            for (int i = 0; i < 52; i++)
            {
                deck.Draw();
            }

            var karte = deck.Draw();

            Assert.That(karte, Is.Null);
        }

        [Test]
        public void NeuesDeck_HatAlleFarben()
        {
            var mockRandom = new MockRandom([0]);
            var deck = new Deck(mockRandom);

            var karten = new List<Card>();
            for (int i = 0; i < 52; i++)
            {
                var karte = deck.Draw();
                if (karte != null)
                {
                    karten.Add(karte);
                }
            }

            var farben = karten.Select(k => k.Suit).Distinct().ToList();

            Assert.That(farben, Has.Count.EqualTo(4));
            Assert.That(farben, Contains.Item("Herz"));
            Assert.That(farben, Contains.Item("Karo"));
            Assert.That(farben, Contains.Item("Pik"));
            Assert.That(farben, Contains.Item("Kreuz"));
        }

        [Test]
        public void NeuesDeck_HatAlleRaenge()
        {
            var mockRandom = new MockRandom([0]);
            var deck = new Deck(mockRandom);

            var karten = new List<Card>();
            for (int i = 0; i < 52; i++)
            {
                var karte = deck.Draw();
                if (karte != null)
                {
                    karten.Add(karte);
                }
            }

            var raenge = karten.Select(k => k.Rank).Distinct().ToList();

            Assert.That(raenge, Has.Count.EqualTo(13));
            Assert.That(raenge, Contains.Item("2"));
            Assert.That(raenge, Contains.Item("3"));
            Assert.That(raenge, Contains.Item("4"));
            Assert.That(raenge, Contains.Item("5"));
            Assert.That(raenge, Contains.Item("6"));
            Assert.That(raenge, Contains.Item("7"));
            Assert.That(raenge, Contains.Item("8"));
            Assert.That(raenge, Contains.Item("9"));
            Assert.That(raenge, Contains.Item("10"));
            Assert.That(raenge, Contains.Item("Bube"));
            Assert.That(raenge, Contains.Item("Dame"));
            Assert.That(raenge, Contains.Item("König"));
            Assert.That(raenge, Contains.Item("Ass"));
        }

        [Test]
        public void Shuffle_WirftKeineException()
        {
            var mockRandom = new MockRandom(Enumerable.Repeat(0, 52));
            var deck = new Deck(mockRandom);

            Assert.DoesNotThrow(deck.Shuffle);
        }
    }
}
