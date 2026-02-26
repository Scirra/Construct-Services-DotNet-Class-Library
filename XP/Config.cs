namespace ConstructServices.XP;
internal static class Config
{
    internal static string APIDomain => 
        !GlobalConfig.DevMode ? "https://xp.construct.net" : "https://xp.constructdev.net";
}