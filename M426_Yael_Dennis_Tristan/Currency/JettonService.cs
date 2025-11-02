namespace M426_Yael_Dennis_Tristan.Currency
{
    public class JettonService : IJettonService
    {
        private const int StartAmount = 1000;

        public int Balance { get; private set; }

        public JettonService()
        {
            Balance = StartAmount;
        }

        public bool CanPlaceBet(int amount)
        {
            return amount > 0 && amount <= Balance;
        }

        public void PlaceBet(int amount)
        {
            if (!CanPlaceBet(amount))
                throw new InvalidOperationException("Ungültiger Einsatz oder unzureichendes Guthaben.");

            Balance -= amount;
        }

        public void AddWinnings(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Gewinnbetrag darf nicht negativ sein.");
            Balance += amount;
        }

        public void Reset(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Startbetrag darf nicht negativ sein.");
            Balance = amount;
        }
    }
}