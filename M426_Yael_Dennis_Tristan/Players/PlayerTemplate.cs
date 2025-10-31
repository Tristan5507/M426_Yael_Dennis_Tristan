namespace M426_Yael_Dennis_Tristan.Players
{
    public class PlayerTemplate
    {
        public string Name { get; }
        public PlayerType PlayerType { get; }

        public PlayerTemplate(string name, PlayerType playerType)
        {
            Name = name;
            PlayerType = playerType;
        }
    }
}
