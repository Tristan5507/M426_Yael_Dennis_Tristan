namespace M426_Yael_Dennis_Tristan.Utilities
{
    public interface IRandomNumberGenerator
    {
        int Next();
        int Next(int maxValue);
        int Next(int minValue, int maxValue);
    }
}
