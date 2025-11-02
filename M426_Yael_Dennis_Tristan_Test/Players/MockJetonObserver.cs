using M426_Yael_Dennis_Tristan;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Players
{
public class MockJetonObserver : IJetonObserver
{
    public bool Notified { get; private set; } = false;

    // Muss genau so heißen wie in IJetonObserver
    public void Notify(APlayer player)
    {
        Notified = true;
    }
}
}