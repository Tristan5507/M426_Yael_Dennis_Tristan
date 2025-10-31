namespace M426_Yael_Dennis_Tristan.Utilities
{
    /// <summary>
    ///     Generates random numbers.
    /// </summary>
    public interface IRandom
    {
        /// <summary>
        ///     Generates a random integer.
        /// </summary>
        /// <returns>A random integer.</returns>
        int Next();

        /// <summary>
        ///     Generates a random integer up to a maximum value.
        /// </summary>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>A random integer.</returns>
        int Next(int maxValue);

        /// <summary>
        ///     Generates a random integer between a minimum and maximum value.
        /// </summary>
        /// <param name="minValue">The minimum value.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>A random integer.</returns>
        int Next(int minValue, int maxValue);
    }
}
