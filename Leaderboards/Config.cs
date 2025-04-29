namespace ConstructServices.Leaderboards
{
    internal class Config
    {
        internal static string APIDomain
        {
            get
            {
                if (!GlobalConfig.DevMode) return "https://leaderboards.construct.net";
                return "https://leaderboards.constructdev.net";
            }
        }
    }
}
