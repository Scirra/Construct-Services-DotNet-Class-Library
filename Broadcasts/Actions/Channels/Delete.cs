using System;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;
public static partial class Channels
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Delete an existing Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/delete-channel" />
        [UsedImplicitly]
        public BaseResponse DeleteChannel(Guid channelID)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Channels.Delete,
                service,
                DeleteChannelOptions.BuildFormData(channelID)
            );
        }

        /// <summary>
        /// Delete an existing Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/delete-channel" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteChannelAsync(Guid channelID)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Channels.Delete,
                service,
                DeleteChannelOptions.BuildFormData(channelID)
            );
        }
    }

    private static class DeleteChannelOptions
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