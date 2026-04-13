namespace ConstructServices.Achievements;

internal static class Config
{
    internal static string APIDomain => 
        !GlobalConfig.DevMode ? "https://achievements.construct.net" : "https://achievements.constructdev.net";
    
    internal static class EndPointPaths
    {
        internal const string Award = "/award.json";
        internal const string Create = "/createachievement.json";
        internal const string Delete = "/deleteachievement.json";
        internal const string Get = "/getachievement.json";
        internal const string List = "/listachievements.json";
        internal const string ListPlayerAchievements = "/listplayerachievements.json";
        internal const string Update = "/updateachievement.json";
    }
}