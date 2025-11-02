using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{

    public interface ICurrencyConsoleService
    {
        void RenderBalances(IEnumerable<APlayer> players);
        void RenderBetConfirmation(IEnumerable<APlayer> players);
        void RenderWinner(APlayer winner);
        void RenderLoser(APlayer loser);
        void RenderInvalidBet();
        public void ClearLastRow();
        public void PrintAt(int x, int y, String str);
    }
}