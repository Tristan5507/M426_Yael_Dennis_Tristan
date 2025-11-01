using M426_Yael_Dennis_Tristan.Bingo;
using M426_Yael_Dennis_Tristan.Currency;

namespace M426_Yael_Dennis_Tristan.Players
{
    public class BingoPlayer : APlayer
    {
        private readonly IBingoBoard _board;

        public BingoPlayer(string name, PlayerType playerType, IBingoBoard board, IJettonService jettonService, IBettingService bettingService) : base(name, playerType, jettonService, bettingService)
        {
            _board = board;
        }

        public void MarkNumber(int number) => _board.MarkNumber(number);
        public bool HasBingo() => _board.HasBingo();
        public int[] GetWinningNumbers () => _board.GetWinningNumbers();
        public BingoField[,] GetFields() => _board.Fields;
    }
}
