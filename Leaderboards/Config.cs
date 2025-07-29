namespace ConstructServices.Leaderboards;

internal static class Config
{
    internal static string APIDomain
    {
        get
        {
            if (!GlobalConfig.DevMode) return "https://leaderboards.construct.net";
            return "https://leaderboards.constructdev.net";
        }
    }
}