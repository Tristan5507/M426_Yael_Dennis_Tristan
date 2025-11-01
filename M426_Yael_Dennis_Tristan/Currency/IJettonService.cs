namespace M426_Yael_Dennis_Tristan.Currency
{
    public interface IJettonService
    {
        int Balance { get; }
        bool CanPlaceBet(int amount);
        void PlaceBet(int amount);
        void AddWinnings(int amount);
        void Reset(int amount);
    }
}