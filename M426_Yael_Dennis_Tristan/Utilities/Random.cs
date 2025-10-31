namespace M426_Yael_Dennis_Tristan.Utilities
{
    /// <inheritdoc/>
    public class DefaultRandom : IRandom
    {
        private readonly Random _random;

        public DefaultRandom()
        {
            _random = new Random();
        }

        /// <inheritdoc/>
        public int Next()
        {
            return _random.Next();
        }

        /// <inheritdoc/>
        public int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }

        /// <inheritdoc/>
        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}
