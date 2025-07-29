namespace ConstructServices.Leaderboards;

internal static class Config
{
    internal static string APIDomain => !GlobalConfig.DevMode ? "https://leaderboards.construct.net" : "https://leaderboards.constructdev.net";
}