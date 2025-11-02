using M426_Yael_Dennis_Tristan.Utilities;

namespace M426_Yael_Dennis_Tristan.Bingo
{
    /// <inheritdoc/>
    public class NumberCaller : INumberCaller
    {
        private readonly Queue<int> _numbers;

        public NumberCaller(int min, int max, IRandom random)
        {
            var shuffled = Enumerable.Range(min, max - min + 1)
                                     .OrderBy(_ => random.Next())
                                     .ToList();
            _numbers = new Queue<int>(shuffled);
        }

        /// <inheritdoc/>
        public int CallNext()
        {
            return _numbers.Count > 0 ? _numbers.Dequeue() : -1;
        }
    }
}
