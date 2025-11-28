using ConstructServices.Broadcasts.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Get
{    
    /// <summary>
    /// Get all channels in this game
    /// </summary>
    [UsedImplicitly]
    public static ChannelResponse DoGetChannel(
        BroadcastService service,
        Guid channelID)
    {
        var formData = new Dictionary<string, string>
        {
            {"channelID", channelID.ToString() }
        };
        
        const string path = "/getchannel.json";
        return Task.Run(() => Request.ExecuteRequest<ChannelResponse>(
            path,
            service,
            formData
        )).Result;
    }
}