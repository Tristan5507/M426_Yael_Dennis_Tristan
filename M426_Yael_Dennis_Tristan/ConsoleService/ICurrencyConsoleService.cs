using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{

    public interface ICurrencyConsoleService
    {
        void AskForBet();
        void RenderBalances(List<APlayer> players);
        void RenderBetConfirmation(List<APlayer> players);
        void RenderWinner(APlayer winner);
        void RenderLoser(APlayer loser);
    }
}