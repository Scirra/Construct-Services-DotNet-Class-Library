namespace ConstructServices.Broadcasts;

internal static class Config
{
    internal static string APIDomain => 
        !GlobalConfig.DevMode ? "https://broadcasts.construct.net" : "https://broadcasts.constructdev.net";
    
    internal static class EndPointPaths
    {
        internal static class Channels
        {
            internal const string Create = "/createchannel.json";
            internal const string Delete = "/deletechannel.json";
            internal const string Get = "/getchannel.json";
            internal const string List = "/getchannels.json";
            internal const string Update = "/updatechannel.json";
        }

        internal static class Messages
        {
            internal const string Create = "/createmessage.json";
            internal const string Delete = "/deletemessage.json";
            internal const string Get = "/getmessage.json";
            internal const string List = "/getmessages.json";
            internal const string Update = "/updatemessage.json";
        }

        internal static class Ratings
        {
            internal const string CreateDimension = "/channelcreateratingdimension.json";
            internal const string DeleteDimension = "/channeldeleteratingsdimension.json";
            internal const string UpdateDimension = "/channeleditratingdimension.json";
            internal const string ListDimensions = "/channelgetratingdimensions.json";
            internal const string Rate = "/rate.json";
        }
    }
}