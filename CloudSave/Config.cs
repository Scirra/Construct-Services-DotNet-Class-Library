namespace ConstructServices.CloudSave;

internal static class Config
{
    internal static string APIDomain
    {
        get
        {
            if (!GlobalConfig.DevMode) return "https://cloudsave.construct.net";
            return "https://cloudsave.constructdev.net";
        }
    }
}