using M426_Yael_Dennis_Tristan.BlackJack;

namespace M426_Yael_Dennis_Tristan_Test.BlackJack
{
    [TestFixture]
    public class HandTests : BlackJackTestBase
    {
        [Test]
        public void NormaleKarte_Hinzufuegen_HandHatEineKarte()
        {
            var hand = new Hand();
            var karte = CreateFuenf();

            hand.AddCard(karte);

            Assert.That(hand.GetCards().Count, Is.EqualTo(1));
        }

        [Test]
        public void MehrereKarten_Hinzufuegen_HandHatAlleKarten()
        {
            var hand = new Hand();
            var karte1 = CreateZwei();
            var karte2 = CreateFuenf();
            var karte3 = CreateKoenig();

            hand.AddCard(karte1);
            hand.AddCard(karte2);
            hand.AddCard(karte3);

            Assert.That(hand.GetCards(), Has.Count.EqualTo(3));
        }

        [Test]
        public void Null_Hinzufuegen_HandBleibtLeer()
        {
            var hand = new Hand();

            hand.AddCard(null);

            Assert.That(hand.GetCards(), Is.Empty);
        }

        [Test]
        public void LeereHand_GetValue_Null()
        {
            var hand = new Hand();

            var wert = hand.GetValue();

            Assert.That(wert, Is.EqualTo(0));
        }

        [Test]
        public void EineZahlkarte_GetValue_RichtigerWert()
        {
            var hand = new Hand();
            var karte = CreateFuenf();

            hand.AddCard(karte);

            Assert.That(hand.GetValue(), Is.EqualTo(5));
        }

        [Test]
        public void ZweiZahlkarten_GetValue_Summe()
        {
            var hand = new Hand();
            var karte1 = CreateFuenf();
            var karte2 = CreateDrei();

            hand.AddCard(karte1);
            hand.AddCard(karte2);

            Assert.That(hand.GetValue(), Is.EqualTo(8));
        }

        [Test]
        public void Koenig_GetValue_Zehn()
        {
            var hand = new Hand();
            var karte = CreateKoenig();

            hand.AddCard(karte);

            Assert.That(hand.GetValue(), Is.EqualTo(10));
        }

        [Test]
        public void Ass_Alleine_GetValue_Elf()
        {
            var hand = new Hand();
            var karte = CreateAss();

            hand.AddCard(karte);

            Assert.That(hand.GetValue(), Is.EqualTo(11));
        }

        [Test]
        public void Ass_Und_Koenig_GetValue_Einundzwanzig()
        {
            var hand = new Hand();
            var ass = CreateAss();
            var koenig = CreateKoenig();

            hand.AddCard(ass);
            hand.AddCard(koenig);

            Assert.That(hand.GetValue(), Is.EqualTo(21));
        }

        [Test]
        public void Ass_Koenig_Fuenf_AssWirdEins()
        {
            var hand = new Hand();
            var ass = CreateAss();
            var koenig = CreateKoenig();
            var fuenf = CreateFuenf();

            hand.AddCard(ass);
            hand.AddCard(koenig);
            hand.AddCard(fuenf);

            Assert.That(hand.GetValue(), Is.EqualTo(16));
        }

        [Test]
        public void ZweiAsse_GetValue_Zwoelf()
        {
            var hand = new Hand();
            var ass1 = CreateAss();
            var ass2 = CreateAss();

            hand.AddCard(ass1);
            hand.AddCard(ass2);

            Assert.That(hand.GetValue(), Is.EqualTo(12));
        }

        [Test]
        public void ZweiAsse_Neun_GetValue_Einundzwanzig()
        {
            var hand = new Hand();
            var ass1 = CreateAss();
            var ass2 = CreateAss();
            var neun = CreateZahlkarte(9);

            hand.AddCard(ass1);
            hand.AddCard(ass2);
            hand.AddCard(neun);

            Assert.That(hand.GetValue(), Is.EqualTo(21));
        }

        [Test]
        public void EineKarte_GetFirstCard_GibtDieseKarte()
        {
            var hand = new Hand();
            var koenig = CreateKoenig();

            hand.AddCard(koenig);

            Assert.That(hand.GetFirstCard(), Is.EqualTo(koenig));
        }

        [Test]
        public void MehrereKarten_GetFirstCard_GibtErsteKarte()
        {
            var hand = new Hand();
            var fuenf = CreateFuenf();
            var koenig = CreateKoenig();

            hand.AddCard(fuenf);
            hand.AddCard(koenig);

            Assert.That(hand.GetFirstCard(), Is.EqualTo(fuenf));
        }

        [Test]
        public void LeereHand_GetFirstCard_WirftException()
        {
            var hand = new Hand();

            Assert.Throws<InvalidOperationException>(() => hand.GetFirstCard());
        }

        [Test]
        public void KartenHinzufuegen_Clear_HandIstLeer()
        {
            var hand = new Hand();
            hand.AddCard(CreateAss());
            hand.AddCard(CreateKoenig());

            hand.Clear();

            Assert.That(hand.GetCards(), Is.Empty);
        }

        [Test]
        public void Clear_GetValue_Null()
        {
            var hand = new Hand();
            hand.AddCard(CreateAss());
            hand.AddCard(CreateKoenig());

            hand.Clear();

            Assert.That(hand.GetValue(), Is.EqualTo(0));
        }

        [Test]
        public void GetCards_GibtAlleKarten()
        {
            var hand = new Hand();
            var ass = CreateAss();
            var koenig = CreateKoenig();

            hand.AddCard(ass);
            hand.AddCard(koenig);

            var karten = hand.GetCards();

            Assert.That(karten.Count, Is.EqualTo(2));
            Assert.That(karten[0], Is.EqualTo(ass));
            Assert.That(karten[1], Is.EqualTo(koenig));
        }
    }
}
