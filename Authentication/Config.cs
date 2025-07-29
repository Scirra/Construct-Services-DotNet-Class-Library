namespace ConstructServices.Authentication;

internal static class Config
{
    internal static string APIDomain => !GlobalConfig.DevMode ? "https://auth.construct.net" : "https://auth.constructdev.net";
}