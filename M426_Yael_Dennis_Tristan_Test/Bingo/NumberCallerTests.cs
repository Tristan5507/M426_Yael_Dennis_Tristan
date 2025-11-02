using M426_Yael_Dennis_Tristan.Bingo;
using M426_Yael_Dennis_Tristan.Utilities;
using M426_Yael_Dennis_Tristan_Test.Mocks;

namespace M426_Yael_Dennis_Tristan_Test.Bingo
{
    [TestFixture]
    public class NumberCallerTests
    {
        [Test]
        public void CallNextTest()
        {
            IRandom random = new MockRandom([1, 2, 3, 4, 5]);
            NumberCaller numberCaller = new NumberCaller(1, 5, random);

            var number = numberCaller.CallNext();
            Assert.That(number, Is.EqualTo(1));

            number = numberCaller.CallNext();
            Assert.That(number, Is.EqualTo(2));

            number = numberCaller.CallNext();
            Assert.That(number, Is.EqualTo(3));

            number = numberCaller.CallNext();
            Assert.That(number, Is.EqualTo(4));

            number = numberCaller.CallNext();
            Assert.That(number, Is.EqualTo(5));

            number = numberCaller.CallNext();
            Assert.That(number, Is.EqualTo(-1));
        }
    }
}
