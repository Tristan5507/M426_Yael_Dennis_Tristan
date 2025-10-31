using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.Factories
{
    public interface IPlayerFactory
    {
        List<BlackJackPlayer> CreateBlackJackPlayers(List<PlayerTemplate> templates);
        List<BingoPlayer> CreateBingoPlayers(List<PlayerTemplate> templates);
    }
}
