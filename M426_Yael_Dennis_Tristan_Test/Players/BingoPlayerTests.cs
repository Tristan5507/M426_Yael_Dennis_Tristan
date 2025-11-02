using M426_Yael_Dennis_Tristan.Bingo;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Players
{
[TestFixture]
public class BingoPlayerTests
{
    [Test]
    public void MarkNumber_DelegatesToBoard()
    {
        var behavior = new MockPlayerTypeBehavior();
        var board = new MockBingoBoard();
        var player = new BingoPlayer("Bob", behavior, board);

        player.MarkNumber(42);

        Assert.That(board.MarkNumberCalled);
        Assert.That(board.LastMarkedNumber, Is.EqualTo(42));
    }

    [Test]
    public void HasBingo_DelegatesToBoard()
    {
        var behavior = new MockPlayerTypeBehavior();
        var board = new MockBingoBoard() { HasBingoReturn = true };
        var player = new BingoPlayer("Bob", behavior, board);

        Assert.That(player.HasBingo());
    }

    [Test]
    public void GetWinningNumbers_DelegatesToBoard()
    {
        var behavior = new MockPlayerTypeBehavior();
        var board = new MockBingoBoard() { WinningNumbersReturn = new[] { 1, 2, 3 } };
        var player = new BingoPlayer("Bob", behavior, board);

        Assert.That(player.GetWinningNumbers(), Is.EqualTo(new[] { 1, 2, 3 }));
    }

    [Test]
    public void GetFields_DelegatesToBoard()
    {
        var behavior = new MockPlayerTypeBehavior();
        var board = new MockBingoBoard() { FieldsReturn = new BingoField[2, 2] };
        var player = new BingoPlayer("Bob", behavior, board);

        Assert.That(player.GetFields(), Is.EqualTo(board.FieldsReturn));
    }
}
}