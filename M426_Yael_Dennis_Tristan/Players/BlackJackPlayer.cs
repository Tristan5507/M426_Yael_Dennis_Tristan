using M426_Yael_Dennis_Tristan.BlackJack;

namespace M426_Yael_Dennis_Tristan.Players
{
    public class BlackJackPlayer : IPlayer
    {
        public string Name { get; }
        public PlayerType PlayerType { get; }
        public IHand Hand { get; private set; }

        public BlackJackPlayer(PlayerTemplate playerTemplate, IHand hand)
        {
            Name = playerTemplate.Name;
            PlayerType = playerTemplate.PlayerType;
            Hand = hand;
        }

        public void AddCard(Card card) => Hand.AddCard(card);
        public int GetHandValue() => Hand.GetValue();
        public void ClearHand() => Hand.Clear();
    }
}
