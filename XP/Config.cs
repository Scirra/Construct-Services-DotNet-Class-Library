namespace ConstructServices.XP;
internal static class Config
{
    internal static string APIDomain => 
        !GlobalConfig.DevMode ? "https://xp.construct.net" : "https://xp.constructdev.net";

    internal const string CreateBonusAPIPath = "/createbonus.json";
    internal const string DeleteBonusAPIPath = "/deletebonus.json";
    internal const string EditBonusAPIPath = "/editbonus.json";
    internal const string ListBonusesAPIPath = "/listbonuses.json";
    internal const string GetBonusAPIPath = "/getbonus.json";
    internal const string CreateRankAPIPath = "/createrank.json";
    internal const string DeleteRankAPIPath = "/deleterank.json";
    internal const string EditRankAPIPath = "/editrank.json";
    internal const string GetRanksAPIPath = "/listranks.json";
    internal const string AddXPAPIPath = "/addxp.json";
    internal const string GetXPAPIPath = "/get.json";
    internal const string RemoveXPAPIPath = "/removexp.json";
    internal const string SetXPAPIPath = "/setxp.json";
}