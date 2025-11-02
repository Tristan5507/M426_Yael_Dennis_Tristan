using M426_Yael_Dennis_Tristan.BlackJack;

namespace M426_Yael_Dennis_Tristan_Test
{
    public abstract class BlackJackTestBase
    {
        protected Card CreateCard(string suit, string rank, int value)
        {
            return new Card(suit, rank, value);
        }

        protected Card CreateAss()
        {
            return new Card("Herz", "Ass", 11);
        }

        protected Card CreateKoenig()
        {
            return new Card("Pik", "König", 10);
        }

        protected Card CreateDame()
        {
            return new Card("Karo", "Dame", 10);
        }

        protected Card CreateBube()
        {
            return new Card("Kreuz", "Bube", 10);
        }

        protected Card CreateZwei()
        {
            return new Card("Herz", "2", 2);
        }

        protected Card CreateDrei()
        {
            return new Card("Karo", "3", 3);
        }

        protected Card CreateFuenf()
        {
            return new Card("Pik", "5", 5);
        }

        protected Card CreateZehn()
        {
            return new Card("Kreuz", "10", 10);
        }

        protected Card CreateZahlkarte(int wert)
        {
            return new Card("Herz", wert.ToString(), wert);
        }
    }
}
