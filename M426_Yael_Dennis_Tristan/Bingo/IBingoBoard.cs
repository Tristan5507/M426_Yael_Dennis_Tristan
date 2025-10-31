namespace M426_Yael_Dennis_Tristan.Bingo
{
    public interface IBingoBoard
    {
        BingoField[,] Fields { get; }
        void MarkNumber(int number);
        bool HasBingo();
    }
}
