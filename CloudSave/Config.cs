namespace ConstructServices.CloudSave;

internal static class Config
{
    internal static string APIDomain => 
        !GlobalConfig.DevMode ? "https://cloudsave.construct.net" : "https://cloudsave.constructdev.net";
}