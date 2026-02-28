using System.Threading.Tasks;
using ConstructServices.Broadcasts.Objects;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Channels
{    
    extension(BroadcastService service)
    {
        /// <summary>
        /// Get an existing Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/get-channel" />
        [UsedImplicitly]
        public ChannelResponse GetChannel(GetChannelOptions getChannelOptions)
        {
            return Request.ExecuteSyncRequest<ChannelResponse>(
                Config.GetChannelAPIPath,
                service,
                getChannelOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Get an existing Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/get-channel" />
        [UsedImplicitly]
        public async Task<ChannelResponse> GetChannelAsync(GetChannelOptions getChannelOptions)
        {
            return await Request.ExecuteAsyncRequest<ChannelResponse>(
                Config.GetChannelAPIPath,
                service,
                getChannelOptions.BuildFormData()
            );
        }
    }
}