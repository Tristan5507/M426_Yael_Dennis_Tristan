using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.Players;
using M426_Yael_Dennis_Tristan_Test.Mocks;

namespace M426_Yael_Dennis_Tristan_Test.BlackJack
{
    [TestFixture]
    public class BlackJackGameTests : BlackJackTestBase
    {
        [Test]
        public void Play_RuftShuffleAuf()
        {
            var mockDealer = new MockBlackJackDealer();
            mockDealer.HandWert = 17;
            mockDealer.KarteZumZurueckgeben = CreateFuenf();
            var mockConsole = new MockBlackJackConsoleService();
            var mockHand = new MockHand();
            mockHand.WertZumZurueckgeben = 20;
            var mockBehavior = new MockPlayerTypeBehavior();
            var player = new MockBlackJackPlayer("Spieler", "s", mockHand, mockBehavior, mockConsole);
            var players = new List<ABlackJackPlayer> { player };
            var game = new BlackJackGame(players, mockDealer, mockConsole);

            game.Play();

            Assert.That(mockDealer.ShuffleWurdeAufgerufen, Is.True);
        }

        [Test]
        public void Play_RuftDealerClearHandAuf()
        {
            var mockDealer = new MockBlackJackDealer();
            mockDealer.HandWert = 17;
            mockDealer.KarteZumZurueckgeben = CreateFuenf();
            var mockConsole = new MockBlackJackConsoleService();
            var mockHand = new MockHand();
            mockHand.WertZumZurueckgeben = 20;
            var mockBehavior = new MockPlayerTypeBehavior();
            var player = new MockBlackJackPlayer("Spieler", "s", mockHand, mockBehavior, mockConsole);
            var players = new List<ABlackJackPlayer> { player };
            var game = new BlackJackGame(players, mockDealer, mockConsole);

            game.Play();

            Assert.That(mockDealer.ClearHandWurdeAufgerufen, Is.True);
        }

        [Test]
        public void Play_RuftPlayerClearHandAuf()
        {
            var mockDealer = new MockBlackJackDealer();
            mockDealer.HandWert = 17;
            mockDealer.KarteZumZurueckgeben = CreateFuenf();
            var mockConsole = new MockBlackJackConsoleService();
            var mockHand = new MockHand();
            mockHand.WertZumZurueckgeben = 20;
            var mockBehavior = new MockPlayerTypeBehavior();
            var player = new MockBlackJackPlayer("Spieler", "s", mockHand, mockBehavior, mockConsole);
            var players = new List<ABlackJackPlayer> { player };
            var game = new BlackJackGame(players, mockDealer, mockConsole);

            game.Play();

            Assert.That(mockHand.ClearWurdeAufgerufen, Is.True);
        }

        [Test]
        public void Play_GibtGameResultZurueck()
        {
            var mockDealer = new MockBlackJackDealer();
            mockDealer.HandWert = 17;
            mockDealer.KarteZumZurueckgeben = CreateFuenf();
            var mockConsole = new MockBlackJackConsoleService();
            var mockHand = new MockHand();
            mockHand.WertZumZurueckgeben = 20;
            var mockBehavior = new MockPlayerTypeBehavior();
            var player = new MockBlackJackPlayer("Spieler", "s", mockHand, mockBehavior, mockConsole);
            var players = new List<ABlackJackPlayer> { player };
            var game = new BlackJackGame(players, mockDealer, mockConsole);

            var result = game.Play();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void SpielerHoeherAlsDealer_SpielerGewinnt()
        {
            var mockDealer = new MockBlackJackDealer();
            mockDealer.HandWert = 19;
            mockDealer.KarteZumZurueckgeben = CreateFuenf();
            var mockConsole = new MockBlackJackConsoleService();
            var mockHand = new MockHand();
            mockHand.WertZumZurueckgeben = 20;
            var mockBehavior = new MockPlayerTypeBehavior();
            var player = new MockBlackJackPlayer("Spieler", "s", mockHand, mockBehavior, mockConsole);
            var players = new List<ABlackJackPlayer> { player };
            var game = new BlackJackGame(players, mockDealer, mockConsole);

            var result = game.Play();

            Assert.That(result.Winners, Has.Count.EqualTo(1));
            Assert.That(result.Winners[0], Is.EqualTo(player));
        }

        [Test]
        public void SpielerUeberkauft_SpielerVerliert()
        {
            var mockDealer = new MockBlackJackDealer();
            mockDealer.HandWert = 20;
            mockDealer.KarteZumZurueckgeben = CreateFuenf();
            var mockConsole = new MockBlackJackConsoleService();
            var mockHand = new MockHand();
            mockHand.WertZumZurueckgeben = 22;
            var mockBehavior = new MockPlayerTypeBehavior();
            var player = new MockBlackJackPlayer("Spieler", "s", mockHand, mockBehavior, mockConsole);
            var players = new List<ABlackJackPlayer> { player };
            var game = new BlackJackGame(players, mockDealer, mockConsole);

            var result = game.Play();

            Assert.That(result.Winners, Is.Empty);
        }

        [Test]
        public void DealerUeberkauft_SpielerGewinnt()
        {
            var mockDealer = new MockBlackJackDealer();
            mockDealer.HandWert = 22;
            mockDealer.KarteZumZurueckgeben = CreateFuenf();
            var mockConsole = new MockBlackJackConsoleService();
            var mockHand = new MockHand();
            mockHand.WertZumZurueckgeben = 20;
            var mockBehavior = new MockPlayerTypeBehavior();
            var player = new MockBlackJackPlayer("Spieler", "s", mockHand, mockBehavior, mockConsole);
            var players = new List<ABlackJackPlayer> { player };
            var game = new BlackJackGame(players, mockDealer, mockConsole);

            var result = game.Play();

            Assert.That(result.Winners, Has.Count.EqualTo(1));
            Assert.That(result.Winners[0], Is.EqualTo(player));
        }

        [Test]
        public void Gleichstand_SpielerVerliert()
        {
            var mockDealer = new MockBlackJackDealer();
            mockDealer.HandWert = 20;
            mockDealer.KarteZumZurueckgeben = CreateFuenf();
            var mockConsole = new MockBlackJackConsoleService();
            var mockHand = new MockHand();
            mockHand.WertZumZurueckgeben = 20;
            var mockBehavior = new MockPlayerTypeBehavior();
            var player = new MockBlackJackPlayer("Spieler", "s", mockHand, mockBehavior, mockConsole);
            var players = new List<ABlackJackPlayer> { player };
            var game = new BlackJackGame(players, mockDealer, mockConsole);

            var result = game.Play();

            Assert.That(result.Winners, Is.Empty);
        }

        [Test]
        public void SpielerNiedrigerAlsDealer_SpielerVerliert()
        {
            var mockDealer = new MockBlackJackDealer();
            mockDealer.HandWert = 20;
            mockDealer.KarteZumZurueckgeben = CreateFuenf();
            var mockConsole = new MockBlackJackConsoleService();
            var mockHand = new MockHand();
            mockHand.WertZumZurueckgeben = 19;
            var mockBehavior = new MockPlayerTypeBehavior();
            var player = new MockBlackJackPlayer("Spieler", "s", mockHand, mockBehavior, mockConsole);
            var players = new List<ABlackJackPlayer> { player };
            var game = new BlackJackGame(players, mockDealer, mockConsole);

            var result = game.Play();

            Assert.That(result.Winners, Is.Empty);
        }

        [Test]
        public void SpielerBlackJack_DealerNiedrig_SpielerGewinnt()
        {
            var mockDealer = new MockBlackJackDealer();
            mockDealer.HandWert = 20;
            mockDealer.KarteZumZurueckgeben = CreateFuenf();
            var mockConsole = new MockBlackJackConsoleService();
            var mockHand = new MockHand();
            mockHand.WertZumZurueckgeben = 21;
            var mockBehavior = new MockPlayerTypeBehavior();
            var player = new MockBlackJackPlayer("Spieler", "s", mockHand, mockBehavior, mockConsole);
            var players = new List<ABlackJackPlayer> { player };
            var game = new BlackJackGame(players, mockDealer, mockConsole);

            var result = game.Play();

            Assert.That(result.Winners, Has.Count.EqualTo(1));
            Assert.That(result.Winners[0], Is.EqualTo(player));
        }

        [Test]
        public void MehrereSpieler_NurHoechsteGewinnen()
        {
            var mockDealer = new MockBlackJackDealer();
            mockDealer.HandWert = 19;
            mockDealer.KarteZumZurueckgeben = CreateFuenf();
            var mockConsole = new MockBlackJackConsoleService();

            var mockHand1 = new MockHand();
            mockHand1.WertZumZurueckgeben = 20;
            var mockBehavior1 = new MockPlayerTypeBehavior();
            var player1 = new MockBlackJackPlayer("Spieler1", "s", mockHand1, mockBehavior1, mockConsole);

            var mockHand2 = new MockHand();
            mockHand2.WertZumZurueckgeben = 18;
            var mockBehavior2 = new MockPlayerTypeBehavior();
            var player2 = new MockBlackJackPlayer("Spieler2", "s", mockHand2, mockBehavior2, mockConsole);

            var mockHand3 = new MockHand();
            mockHand3.WertZumZurueckgeben = 21;
            var mockBehavior3 = new MockPlayerTypeBehavior();
            var player3 = new MockBlackJackPlayer("Spieler3", "s", mockHand3, mockBehavior3, mockConsole);

            var players = new List<ABlackJackPlayer> { player1, player2, player3 };
            var game = new BlackJackGame(players, mockDealer, mockConsole);

            var result = game.Play();

            Assert.That(result.Winners, Has.Count.EqualTo(2));
            Assert.That(result.Winners, Contains.Item(player1));
            Assert.That(result.Winners, Contains.Item(player3));
        }
    }
}
