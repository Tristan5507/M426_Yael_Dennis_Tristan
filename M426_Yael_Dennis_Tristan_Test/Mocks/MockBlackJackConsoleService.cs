using M426_Yael_Dennis_Tristan.BlackJack;
using M426_Yael_Dennis_Tristan.ConsoleService;
using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan_Test.Mocks
{
    public class MockBlackJackConsoleService : IBlackJackConsoleService
    {
        public void RenderBust(string playerName)
        {
            throw new NotImplementedException();
        }

        public void RenderCardDraw(string playerName, Card card, int handValue)
        {
            throw new NotImplementedException();
        }

        public void RenderDealerDraw(int handValue)
        {
            throw new NotImplementedException();
        }

        public void RenderDealerFinalValue(int handValue)
        {
            throw new NotImplementedException();
        }

        public void RenderGameHeader(List<ABlackJackPlayer> players)
        {
            throw new NotImplementedException();
        }

        public void RenderInitialHands(Card dealerVisibleCard, List<ABlackJackPlayer> players)
        {
            throw new NotImplementedException();
        }

        public void RenderResults(List<ABlackJackPlayer> players, int dealerValue)
        {
            throw new NotImplementedException();
        }

        public void RenderGameState(IBlackJackDealer dealer, List<ABlackJackPlayer> players, int currentPlayerIndex, bool hideDealerSecondCard)
        {
            throw new NotImplementedException();
        }

        public void RenderRobotDecision(string decision)
        {
            throw new NotImplementedException();
        }

        public void RenderTurnHeader(string playerName)
        {
            throw new NotImplementedException();
        }
    }
}
