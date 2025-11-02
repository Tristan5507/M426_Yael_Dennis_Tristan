namespace M426_Yael_Dennis_Tristan.Players
{
    public abstract class APlayer
    {
        public string Name { get; }
        public APlayer(string name)
        {
            Name = name;
        }
    }
}
