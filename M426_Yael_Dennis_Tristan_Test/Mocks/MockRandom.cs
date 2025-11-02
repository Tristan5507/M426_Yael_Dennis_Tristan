using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockRandom : IRandom
    {
        private int _returnValue;

        public MockRandom(int returnValue)
        {
            _returnValue = returnValue;
        }

        public int Next()
        {
            return _returnValue;
        }

        public int Next(int maxValue)
        {
            return _returnValue;
        }

        public int Next(int minValue, int maxValue)
        {
            return _returnValue;
        }
    }
}
