namespace ConstructServices.Broadcasts;

internal static class Config
{
    internal static string APIDomain => 
        !GlobalConfig.DevMode ? "https://broadcasts.construct.net" : "https://broadcasts.constructdev.net";

    internal const string CreateChannelAPIPath = "/createchannel.json";
    internal const string CreateMessageAPIPath = "/createmessage.json";
    internal const string CreateRatingDimensionAPIPath = "/channelcreateratingdimension.json";
    internal const string DeleteChannelAPIPath = "/deletechannel.json";
    internal const string DeleteMessageAPIPath = "/deletemessage.json";
    internal const string DeleteDimensionAPIPath = "/channeldeleteratingsdimension.json";
    internal const string EditDimensionAPIPath = "/channeleditratingdimension.json";
    internal const string GetChannelAPIPath = "/getchannel.json";
    internal const string GetChannelsAPIPath = "/getchannels.json";
    internal const string GetMessageAPIPath = "/getmessage.json";
    internal const string GetMessagesAPIPath = "/getmessages.json";
    internal const string GetDimensionsAPIPath = "/channelgetratingdimensions.json";
    internal const string UpdateChannelAPIPath = "/updatechannel.json";
    internal const string UpdateMessageAPIPath = "/updatemessage.json";
}