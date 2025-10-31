namespace M426_Yael_Dennis_Tristan.Bingo
{
    /// <inheritdoc/>
    public class NumberCaller : INumberCaller
    {
        private const int Min = 1;
        private const int Max = 75;

        private readonly Queue<int> _numbers;

        public NumberCaller()
        {
            var random = new Random();
            var shuffled = Enumerable.Range(Min, Max - Min +1)
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
