using M426_Yael_Dennis_Tristan.Bingo;
using M426_Yael_Dennis_Tristan.Utilities;
using M426_Yael_Dennis_Tristan_Test.Mocks;

namespace M426_Yael_Dennis_Tristan_Test.Bingo
{
    [TestFixture]
    public class BingoBoardTests
    {
        [Test]
        public void GenerateBoardTest()
        {
            IRandom random = new MockRandom(Enumerable.Range(1, 75));
            BingoBoard bingoBoard = new BingoBoard(random);

            Assert.That(bingoBoard.Fields, Has.Length.EqualTo(25));
            Assert.That(bingoBoard.Fields[0, 0].Number, Is.EqualTo(1));
            Assert.That(!bingoBoard.Fields[0, 0].Checked);
            Assert.That(bingoBoard.Fields[0, 2].Number, Is.EqualTo(3));
            Assert.That(!bingoBoard.Fields[0, 2].Checked);
            Assert.That(bingoBoard.Fields[1, 3].Number, Is.EqualTo(9));
            Assert.That(!bingoBoard.Fields[1, 3].Checked);
            Assert.That(bingoBoard.Fields[2, 1].Number, Is.EqualTo(12));
            Assert.That(!bingoBoard.Fields[2, 1].Checked);
            Assert.That(bingoBoard.Fields[2, 3].Number, Is.EqualTo(14));
            Assert.That(!bingoBoard.Fields[2, 3].Checked);
            Assert.That(bingoBoard.Fields[3, 0].Number, Is.EqualTo(16));
            Assert.That(!bingoBoard.Fields[3, 0].Checked);
            Assert.That(bingoBoard.Fields[3, 4].Number, Is.EqualTo(20));
            Assert.That(!bingoBoard.Fields[3, 4].Checked);
            Assert.That(bingoBoard.Fields[4, 2].Number, Is.EqualTo(23));
            Assert.That(!bingoBoard.Fields[4, 2].Checked);
            Assert.That(bingoBoard.Fields[4, 4].Number, Is.EqualTo(25));
            Assert.That(!bingoBoard.Fields[4, 4].Checked);
        }

        [TestCase(1, 0, 0, TestName = "MarkNumberTest: 1")]
        [TestCase(3, 0, 2, TestName = "MarkNumberTest: 3")]
        [TestCase(9, 1, 3, TestName = "MarkNumberTest: 9")]
        [TestCase(12, 2, 1, TestName = "MarkNumberTest: 12")]
        [TestCase(14, 2, 3, TestName = "MarkNumberTest: 14")]
        [TestCase(16, 3, 0, TestName = "MarkNumberTest: 16")]
        [TestCase(20, 3, 4, TestName = "MarkNumberTest: 20")]
        [TestCase(23, 4, 2, TestName = "MarkNumberTest: 23")]
        [TestCase(25, 4, 4, TestName = "MarkNumberTest: 25")]
        public void MarkNumberTest(int number, int expectedRow, int expectedColumn)
        {
            IRandom random = new MockRandom(Enumerable.Range(1, 75));
            BingoBoard bingoBoard = new BingoBoard(random);

            bingoBoard.MarkNumber(number);

            Assert.That(bingoBoard.Fields[expectedRow, expectedColumn].Checked);
        }

        public void HasBingoTest_NoNumbers()
        {
            IRandom random = new MockRandom(Enumerable.Range(1, 75));
            BingoBoard bingoBoard = new BingoBoard(random);

            var bingo = bingoBoard.HasBingo();

            Assert.That(!bingo);
        }

        [TestCase(1, 2, 3, 4, 6, 7, 8, 9, 11, TestName = "HasBingoTest_NoBingo_Random")]
        [TestCase(1, 7, 13, 19, 24, TestName = "HasBingoTest_NoBingo_AlmostDiagonal")]
        [TestCase(5, 10, 15, 20, TestName = "HasBingoTest_NoBingo_AlmostColumn")]
        [TestCase(1, 2, 3, 4, 6, 11, 12, 13, 14, 16, TestName = "HasBingoTest_NoBingo_AlmostRow")]
        [TestCase(2, 3, 4, 5, 6, 8, 9, 10, 11, 12, 14, 15, 16, 17, 18, 20, 21, 22, 23, 24, TestName = "HasBingoTest_NoBingo_OnlyFiveLeft")]
        public void HasBingoTest_NoBingo(int num1, int num2, int num3, int num4, int? num5 = null,
                                         int? num6 = null, int? num7 = null, int? num8 = null, int? num9 = null, int? num10 = null,
                                         int? num11 = null, int? num12 = null, int? num13 = null, int? num14 = null, int? num15 = null,
                                         int? num16 = null, int? num17 = null, int? num18 = null, int? num19 = null, int? num20 = null)
        {
            var numbers = new int?[] { num1, num2, num3, num4, num5, num6, num7, num8, num9, num10,
                                         num11, num12, num13, num14, num15, num16, num17, num18, num19, num20 }
                                         .Where(n => n.HasValue)
                                         .Select(n => n!.Value);

            IRandom random = new MockRandom(Enumerable.Range(1, 75));
            BingoBoard bingoBoard = new BingoBoard(random);

            foreach (var number in numbers)
            {
                bingoBoard.MarkNumber(number);
            }

            var bingo = bingoBoard.HasBingo();

            Assert.That(!bingo);
        }

        [TestCase(1, 2, 3, 4, 5, TestName = "HasBingoTest_Row1")]
        [TestCase(11, 13, 12, 14, 15, TestName = "HasBingoTest_Row3")]
        [TestCase(21, 24, 23, 22, 25, TestName = "HasBingoTest_Row5")]
        [TestCase(12, 17, 2, 7, 22, TestName = "HasBingoTest_Column2")]
        [TestCase(8, 23, 3, 13, 18, TestName = "HasBingoTest_Column3")]
        [TestCase(4, 19, 24, 9, 14, TestName = "HasBingoTest_Column4")]
        [TestCase(1, 7, 25, 13, 19, TestName = "HasBingoTest_Diagonal1")]
        [TestCase(17, 21, 5, 13, 9, TestName = "HasBingoTest_Diagonal2")]
        public void HasBingoTest(int num1, int num2, int num3, int num4, int num5)
        {
            var numbers = new int[] { num1, num2, num3, num4, num5 };
            IRandom random = new MockRandom(Enumerable.Range(1, 75));
            BingoBoard bingoBoard = new BingoBoard(random);

            foreach (var number in numbers)
            {
                bingoBoard.MarkNumber(number);
            }

            var bingo = bingoBoard.HasBingo();

            Assert.That(bingo);
        }
    }
}
