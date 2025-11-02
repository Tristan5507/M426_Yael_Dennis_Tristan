using M426_Yael_Dennis_Tristan.Bingo;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockNumberCaller : INumberCaller
    {
        private Queue<int> _returnValues;
        public MockNumberCaller(IEnumerable<int> returnValues)
        {
            _returnValues = new Queue<int>(returnValues);
        }

        public int CallNext()
        {
            return _returnValues.Dequeue();
        }
    }
}
