namespace ConstructServices.Authentication
{
    internal class Config
    {
        internal static string APIDomain
        {
            get
            {
                if (!GlobalConfig.DevMode) return "https://auth.construct.net";
                return "https://auth.constructdev.net";
            }
        }
    }
}
