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
        /// Creates a new Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/create-channel" />
        [UsedImplicitly]
        public ChannelResponse CreateChannel(CreateChannelOptions createChannelOptions)
        {
            return Request.ExecuteSyncRequest<ChannelResponse>(
                Config.CreateChannelAPIPath,
                service,
                createChannelOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Creates a new Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/create-channel" />
        [UsedImplicitly]
        public async Task<ChannelResponse> CreateChannelAsync(CreateChannelOptions createChannelOptions)
        {
            return await Request.ExecuteAsyncRequest<ChannelResponse>(
                Config.CreateChannelAPIPath,
                service,
                createChannelOptions.BuildFormData()
            );
        }
    }
}