using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockBlackJackConsoleService : IBlackJackConsoleService
    {
        public void RenderBust(string playerName)
        {
        }

        public void RenderCardDraw(string playerName, Card card, int handValue)
        {
        }

        public void RenderDealerDraw(int handValue)
        {
        }

        public void RenderDealerFinalValue(int handValue)
        {
        }

        public void RenderGameHeader(List<ABlackJackPlayer> players)
        {
        }

        public void RenderInitialHands(Card dealerVisibleCard, List<ABlackJackPlayer> players)
        {
        }

        public void RenderResults(List<ABlackJackPlayer> players, int dealerValue)
        {
        }

        public void RenderGameState(IBlackJackDealer dealer, List<ABlackJackPlayer> players, int currentPlayerIndex, bool hideDealerSecondCard)
        {
        }

        public void RenderRobotDecision(string decision)
        {
        }

        public void RenderTurnHeader(string playerName)
        {
        }
    }
}
