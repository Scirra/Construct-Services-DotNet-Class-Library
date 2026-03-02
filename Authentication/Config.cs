namespace ConstructServices.Authentication;

internal static class Config
{
    internal static string APIDomain => !GlobalConfig.DevMode ? "https://auth.construct.net" : "https://auth.constructdev.net";

    internal static class EndPointPaths
    {
        internal const string ChangePassword = "/changepassword.json";
        internal const string ChangePlayerName = "/changeplayername.json";
        internal const string DeleteAvatar = "/deleteavatar.json";
        internal const string DeletePlayer = "/deleteplayer.json";
        internal const string Disconnect = "/disconnect.json";
        internal const string EndSession = "/endsession.json";
        internal const string ForceLink = "/forcelink.json";
        internal const string ForgottenPassword = "/forgottenpassword.json";
        internal const string ListProviders = "/getconnectedloginproviders.json";
        internal const string GetPlayer = "/getplayer.json";
        internal const string ListPlayers = "/getplayers.json";
        internal const string GetSession = "/getsession.json";
        internal const string Link = "/link.json";
        internal const string Refresh = "/refreshsession.json";
        internal const string Register = "/registerplayer.json";
        internal const string SetAvatar = "/setavatar.json";
        internal const string SetEmailAddress = "/setemailaddress.json";
        internal const string SetRestrictions = "/setplayerrestrictions.json";
        internal const string SetUsernamePassword = "/setusernamepassword.json";
        internal const string SignIn = "/signin.json";
        internal const string SignInPoll = "/signinpoll.json";
    }
}