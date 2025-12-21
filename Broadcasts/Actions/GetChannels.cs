using System.Collections.Generic;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Get
{
    /// <summary>
    /// Get all channels in this game
    /// </summary>
    [UsedImplicitly]
    public static ChannelsResponse GetChannels(
        this BroadcastService service)
    {
        var formData = new Dictionary<string, string>();
        const string path = "/getchannels.json";
        return Request.ExecuteSyncRequest<ChannelsResponse>(
            path,
            service,
            formData
        );
    }
}