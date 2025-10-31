namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    public interface ICasinoConsoleService
    {
        void RenderMainMenu(Dictionary<int, string> games);
        void RenderInvalidSelection();
        void RenderSeparator();
    }
}
