using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockRandom : IRandom
    {
        private Queue<int> _returnValue;

        public MockRandom(IEnumerable<int> returnValue)
        {
            _returnValue = new Queue<int>(returnValue);
        }

        public int Next()
        {
            return _returnValue.Dequeue();
        }

        public int Next(int maxValue)
        {
            return _returnValue.Dequeue();
        }

        public int Next(int minValue, int maxValue)
        {
            return _returnValue.Dequeue();
        }
    }
}
