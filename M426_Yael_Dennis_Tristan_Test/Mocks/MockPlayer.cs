using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockPlayer : APlayer
    {
        public MockPlayer(string name, IPlayerTypeBehavior playerTypeBehavior) : base(name, playerTypeBehavior)
        {
        }
    }
}
