namespace M426_Yael_Dennis_Tristan.Bingo
{
    public class BingoField
    {
        public int Number { get; init; }
        public bool Checked { get; set; }

        public BingoField(int number)
        {
            Number = number;
            Checked = false;
        }
    }
}
