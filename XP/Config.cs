namespace ConstructServices.XP;
internal static class Config
{
    internal static string APIDomain => 
        !GlobalConfig.DevMode ? "https://xp.construct.net" : "https://xp.constructdev.net";

    internal static class EndPointPaths
    {
        internal static class Bonuses
        {
            internal const string Create = "/createbonus.json";
            internal const string Delete = "/deletebonus.json";
            internal const string Update = "/editbonus.json";
            internal const string List = "/listbonuses.json";
            internal const string Get = "/getbonus.json";
        }

        internal static class Rankings
        {
            internal const string Create = "/createrank.json";
            internal const string Delete = "/deleterank.json";
            internal const string Update = "/editrank.json";
            internal const string List = "/listranks.json";
        }

        internal static class XP
        {
            internal const string Add = "/addxp.json";
            internal const string Get = "/get.json";
            internal const string Remove = "/removexp.json";
            internal const string Set = "/setxp.json";
        }
    }
}