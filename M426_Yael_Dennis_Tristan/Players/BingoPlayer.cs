using M426_Yael_Dennis_Tristan.Bingo;

namespace M426_Yael_Dennis_Tristan.Players
{
    public class BingoPlayer : IPlayer
    {
        public string Name { get; }
        internal readonly IBingoBoard Board;

        public BingoPlayer(PlayerTemplate playerTemplate, IBingoBoard board)
        {
            Name = playerTemplate.Name;
            Board = board;
        }

        public void MarkNumber(int number) => Board.MarkNumber(number);
        public bool HasBingo() => Board.HasBingo();
    }
}
