namespace M426_Yael_Dennis_Tristan.Players
{
    public abstract class APlayer
    {
        public string Name { get; }
        public int CurrentBet { get; set; }
        public int Balance { get; private set; }

        private readonly IPlayerTypeBehavior _playerTypeBehavior;

        protected APlayer(string name, IPlayerTypeBehavior playerTypeBehavior)
        {
            Name = name;
            _playerTypeBehavior = playerTypeBehavior;
            Balance = 1000;
        }

        public void PlaceBet()
        {
            CurrentBet = _playerTypeBehavior.GetBet(this);
            Balance -= CurrentBet;
        }

        public void Win()
        {
            Balance -= CurrentBet * 2;
            CurrentBet = 0;
        }

        public void Lose()
        {
            CurrentBet = 0;
        }
    }
}