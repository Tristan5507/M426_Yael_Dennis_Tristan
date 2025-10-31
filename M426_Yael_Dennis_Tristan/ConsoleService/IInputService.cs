using M426_Yael_Dennis_Tristan.Players;

namespace M426_Yael_Dennis_Tristan.ConsoleService
{
    public interface IInputService
    {
        List<PlayerTemplate> GetPlayerTemplates();
        string GetHitOrStandDecision(string playerName);
        string GetGameSelection();
    }
}
