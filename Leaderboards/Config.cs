namespace ConstructServices.Leaderboards;

internal static class Config
{
    internal static string APIDomain => !GlobalConfig.DevMode ? "https://leaderboards.construct.net" : "https://leaderboards.constructdev.net";

    internal static class EndPointPaths
    {
        internal static class Scores
        {
            internal const string Adjust = "/adjustscore.json";
            internal const string Delete = "/deletescores.json";
            internal const string ListNewest = "/getnewestscores.json";
            internal const string ListPlayerScores = "/getplayerscores.json";
            internal const string ListScoreHistory = "/getscorehistory.json";
            internal const string ListScoreNeighbours = "/getscoreneighbours.json";
            internal const string ListScores = "/getscores.json";
            internal const string Create = "/postscore.json";

        }
        internal static class ShadowBans
        {
            internal const string Create = "/shadowban.json";
            internal const string ListIPBans = "/getipshadowbans.json";
            internal const string Delete = "/unshadowban.json";
            internal const string ListPlayerIDBans = "/getplayeridshadowbans.json";
        }
        internal static class Teams
        {
            internal const string Get = "/getteam.json";
            internal const string AssignPlayer = "/assignteamplayer.json";
            internal const string Create = "/createteam.json";
            internal const string Delete = "/deleteteam.json";
            internal const string List = "/listteams.json";
            internal const string ListPlayers = "/listteamplayers.json";
            internal const string DeletePlayer = "/deleteteamplayer.json";
            internal const string Update = "/updateteam.json";
        }
    }
}