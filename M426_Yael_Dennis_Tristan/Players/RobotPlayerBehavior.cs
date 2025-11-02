using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan.Players
{
    public class RobotPlayerBehavior : IPlayerTypeBehavior
    {
        private readonly IRandom _random;
        public RobotPlayerBehavior(IRandom random)
        {
            _random = random;
        }

        public int GetBet(APlayer player)
        {
            return _random.Next(10, Math.Max(20, player.Balance / 5));
        }
    }
}
