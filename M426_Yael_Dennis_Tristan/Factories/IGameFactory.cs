namespace M426_Yael_Dennis_Tristan.Factories
{
    public interface IGameFactory
    {
        IGame? CreateGame(int gameNumber);
    }
}
