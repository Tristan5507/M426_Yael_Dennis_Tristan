using M426_Yael_Dennis_Tristan.Bingo;
using M426_Yael_Dennis_Tristan.Players;
using M426_Yael_Dennis_Tristan_Test.Mocks;

namespace M426_Yael_Dennis_Tristan_Test.Bingo
{
    [TestFixture]
    public class BingoGameTests
    {
        [Test]
        public void PlayTest_NoMoreNumbers()
        {
            IPlayerTypeBehavior behavior = new MockPlayerTypeBehavior();
            IBingoBoard board = new MockBingoBoard(1);
            INumberCaller numberCaller = new MockNumberCaller([-1]);
            MockBingoConsoleService consoleService = new MockBingoConsoleService();

            List<BingoPlayer> players = new()
            {
                new BingoPlayer("TestPlayer", behavior, board)
            };
            BingoGame game = new BingoGame(players, numberCaller, consoleService);

            var result = game.Play();

            Assert.That(result.Winners, Is.Empty);
            Assert.That(consoleService.Messages, Has.Count.EqualTo(1));
            Assert.That(consoleService.Messages.Any(m => m == "Keine weiteren Zahlen!"));
        }

        [Test]
        public void PlayTest_SingleWinner()
        {
            IPlayerTypeBehavior behavior = new MockPlayerTypeBehavior();
            MockBingoBoard board = new MockBingoBoard(5);
            MockBingoBoard board2 = new MockBingoBoard(10);
            INumberCaller numberCaller = new MockNumberCaller([5, -1]);
            MockBingoConsoleService consoleService = new MockBingoConsoleService();

            List<BingoPlayer> players = new()
            {
                new BingoPlayer("Winner", behavior, board),
                new BingoPlayer("Loser", behavior, board2)
            };
            BingoGame game = new BingoGame(players, numberCaller, consoleService);

            var result = game.Play();

            Assert.That(result.Winners, Is.Not.Empty);
            Assert.That(result.Winners, Has.Count.EqualTo(1));
            Assert.That(result.Winners.First().Name, Is.EqualTo("Winner"));

            Assert.That(consoleService.Messages, Is.Empty);
            Assert.That(board.RequiredNumberCalled);
            Assert.That(!board2.RequiredNumberCalled);

            var allPlayers = consoleService.GenerateOutputCalled[0].Item1;
            Assert.That(consoleService.GenerateOutputCalled, Has.Count.EqualTo(1));
            Assert.That(allPlayers, Has.Count.EqualTo(2));
            Assert.That(allPlayers.First().Name, Is.EqualTo("Winner"));
            Assert.That(allPlayers.Skip(1).First().Name, Is.EqualTo("Loser"));
            Assert.That(consoleService.GenerateOutputCalled[0].Item2, Is.EqualTo(5));

            Assert.That(consoleService.GenerateBingoOuputCalled, Has.Count.EqualTo(1));
            Assert.That(consoleService.GenerateBingoOuputCalled[0], Has.Count.EqualTo(1));
            Assert.That(consoleService.GenerateBingoOuputCalled[0].First().Name, Is.EqualTo("Winner"));
        }

        [Test]
        public void PlayTest_MultipleWinners()
        {
            IPlayerTypeBehavior behavior = new MockPlayerTypeBehavior();
            MockBingoBoard board1 = new MockBingoBoard(7);
            MockBingoBoard board2 = new MockBingoBoard(7);
            MockBingoBoard board3 = new MockBingoBoard(10);
            INumberCaller numberCaller = new MockNumberCaller([7, -1]);
            MockBingoConsoleService consoleService = new MockBingoConsoleService();

            List<BingoPlayer> players = new()
            {
                new BingoPlayer("P1", behavior, board1),
                new BingoPlayer("P2", behavior, board2),
                new BingoPlayer("P3", behavior, board3),
            };
            BingoGame game = new BingoGame(players, numberCaller, consoleService);

            var result = game.Play();

            Assert.That(result.Winners.Count, Is.EqualTo(2));
            var winnerNames = result.Winners.Select(w => w.Name).ToList();
            Assert.That(winnerNames, Contains.Item("P1"));
            Assert.That(winnerNames, Contains.Item("P2"));

            Assert.That(consoleService.Messages, Is.Empty);
            Assert.That(board1.RequiredNumberCalled);
            Assert.That(board2.RequiredNumberCalled);
            Assert.That(!board3.RequiredNumberCalled);

            var allPlayers = consoleService.GenerateOutputCalled[0].Item1;
            Assert.That(consoleService.GenerateOutputCalled, Has.Count.EqualTo(1));
            Assert.That(allPlayers, Has.Count.EqualTo(3));
            Assert.That(allPlayers.First().Name, Is.EqualTo("P1"));
            Assert.That(allPlayers.Skip(1).First().Name, Is.EqualTo("P2"));
            Assert.That(allPlayers.Skip(2).First().Name, Is.EqualTo("P3"));
            Assert.That(consoleService.GenerateOutputCalled[0].Item2, Is.EqualTo(7));

            var winners = consoleService.GenerateBingoOuputCalled[0];
            Assert.That(consoleService.GenerateBingoOuputCalled, Has.Count.EqualTo(1));
            Assert.That(winners, Has.Count.EqualTo(2));
            Assert.That(winners.First().Name, Is.EqualTo("P1"));
            Assert.That(winners.Skip(1).First().Name, Is.EqualTo("P2"));
        }
    }
}
