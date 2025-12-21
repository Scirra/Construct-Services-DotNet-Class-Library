namespace ConstructServices.Broadcasts;

internal static class Config
{
    internal static string APIDomain => 
        !GlobalConfig.DevMode ? "https://broadcasts.construct.net" : "https://broadcasts.constructdev.net";
}