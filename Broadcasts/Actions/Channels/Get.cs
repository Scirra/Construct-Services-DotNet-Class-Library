using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Channels
{    
    extension(BroadcastServiceBase service)
    {
        /// <summary>
        /// Get an existing Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/get-channel" />
        [UsedImplicitly]
        public ChannelResponse GetChannel(Guid channelID)
        {
            return Request.ExecuteSyncRequest<ChannelResponse>(
                Config.EndPointPaths.Channels.Get,
                service,
                GetChannelOptions.BuildFormData(channelID)
            );
        }

        /// <summary>
        /// Get an existing Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/get-channel" />
        [UsedImplicitly]
        public async Task<ChannelResponse> GetChannelAsync(Guid channelID)
        {
            return await Request.ExecuteAsyncRequest<ChannelResponse>(
                Config.EndPointPaths.Channels.Get,
                service,
                GetChannelOptions.BuildFormData(channelID)
            );
        }
    }
    private static class GetChannelOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid channelID)
        {
            return new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() }
            };
        }
    }
}