using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Collections.Generic;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Create
{
    /// <summary>
    /// Create a new channel
    /// </summary>
    [UsedImplicitly]
    public static ChannelResponse CreateChannel(
        this BroadcastService service,
        string channelName,
        string channelDescription,
        string languageISO,
        bool allowRatings)
    {
        var formData = new Dictionary<string, string>
        {
            { "name", channelName },
            { "description", channelDescription },
            { "language", languageISO },
            { "allowRatings", allowRatings.ToInt().ToString() }
        };

        const string path = "/createchannel.json";
        return Request.ExecuteSyncRequest<ChannelResponse>(
            path,
            service,
            formData
        );
    }
}