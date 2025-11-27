using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static class Delete
{
    /// <summary>
    /// Create a new channel
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse DeleteChannel(
        this BroadcastService service,
        Guid channelID)
    {
        var formData = new Dictionary<string, string>
        {
            { "channelID", channelID.ToString() }
        };

        const string path = "/deletechannel.json";
        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            formData
        )).Result;
    }
}