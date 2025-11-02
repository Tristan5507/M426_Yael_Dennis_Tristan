namespace M426_Yael_Dennis_Tristan.Players
{
    public abstract class APlayer : IJetonObservable
    {
        public string Name { get; }
        public int CurrentBet { get; set; }

        private int _balance;
        public int Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                _playerTypeBehavior.OnBalanceChanged(this, _observers);
            }
        }

        private readonly IPlayerTypeBehavior _playerTypeBehavior;
        private readonly List<IJetonObserver> _observers = new List<IJetonObserver>();

        protected APlayer(string name, IPlayerTypeBehavior playerTypeBehavior)
        {
            Name = name;
            _playerTypeBehavior = playerTypeBehavior;
            Balance = 1000;
        }

        public void Attach(IJetonObserver observer)
        {
            _observers.Add(observer);
        }

        public void PlaceBet()
        {
            CurrentBet = _playerTypeBehavior.GetBet(this);
            Balance -= CurrentBet;
        }

        public void Win()
        {
            Balance += CurrentBet * 2;
            CurrentBet = 0;
        }

        public void Lose()
        {
            CurrentBet = 0;
        }
    }
}