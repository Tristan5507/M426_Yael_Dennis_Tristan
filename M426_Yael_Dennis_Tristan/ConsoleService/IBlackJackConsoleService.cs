using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    public interface IBlackJackConsoleService
    {
        void RenderGameHeader(IEnumerable<BlackJackPlayer> players);
        void RenderInitialHands(Card dealerVisibleCard, IEnumerable<BlackJackPlayer> players);
        void RenderPlayerTurnHeader(string playerName);
        void RenderCardDraw(string playerName, Card card, int handValue);
        void RenderBust(string playerName);
        void RenderRobotDecision(string decision);
        void RenderDealerTurnHeader();
        void RenderDealerDraw(int handValue);
        void RenderDealerFinalValue(int handValue);
        void RenderResults(IEnumerable<BlackJackPlayer> players, int dealerValue);
        void RenderOverallWinner(IPlayer? winner);
    }
}
