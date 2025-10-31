using M426_Yael_Dennis_Tristan.Bingo;

namespace M426_Yael_Dennis_Tristan.Players
{
    public class BingoPlayer : IPlayer
    {
        public string Name { get; }
        public BingoBoard Board { get; } = new BingoBoard();

        public BingoPlayer(PlayerTemplate playerTemplate)
        {
            Name = playerTemplate.Name;
        }
    }
}
