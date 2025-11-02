using M426_Yael_Dennis_Tristan.Players;


public class TestPlayer : APlayer
{
    public TestPlayer(string name, IPlayerTypeBehavior behavior) : base(name, behavior) { }
}

[TestFixture]
public class APlayerTests
{
    [Test]
    public void Constructor_SetsNameAndDefaultBalance()
    {
        var behavior = new MockPlayerTypeBehavior();
        var player = new TestPlayer("Alice", behavior);

        Assert.That(player.Name, Is.EqualTo("Alice"));
        Assert.That(player.Balance, Is.EqualTo(1000));
    }

    [Test]
    public void Balance_SettingTriggersOnBalanceChanged()
    {
        var behavior = new MockPlayerTypeBehavior();
        var observer = new MockJetonObserver();
        var player = new TestPlayer("Alice", behavior);
        player.Attach(observer);

        player.Balance = 900;

        Assert.That(behavior.BalanceChangedCalled, Is.True);
        Assert.That(observer.Notified, Is.True);
        Assert.That(player.Balance, Is.EqualTo(900));
    }

    [Test]
    public void PlaceBet_SetsCurrentBetAndReducesBalance()
    {
        var behavior = new MockPlayerTypeBehavior() { BetToReturn = 200 };
        var player = new TestPlayer("Alice", behavior);

        player.PlaceBet();

        Assert.That(player.CurrentBet, Is.EqualTo(200));
        Assert.That(player.Balance, Is.EqualTo(800));
    }

    [Test]
    public void Win_AddsWinningsAndResetsCurrentBet()
    {
        var behavior = new MockPlayerTypeBehavior();
        var player = new TestPlayer("Alice", behavior);

        player.CurrentBet = 100;
        player.Win();

        Assert.That(player.Balance, Is.EqualTo(1200));
        Assert.That(player.CurrentBet, Is.EqualTo(0));
    }

    [Test]
    public void Lose_ResetsCurrentBetOnly()
    {
        var behavior = new MockPlayerTypeBehavior();
        var player = new TestPlayer("Alice", behavior);

        player.CurrentBet = 100;
        player.Lose();

        Assert.That(player.Balance, Is.EqualTo(1000));
        Assert.That(player.CurrentBet, Is.EqualTo(0));
    }
}
