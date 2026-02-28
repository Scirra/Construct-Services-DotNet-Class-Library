using ConstructServices.Broadcasts.Objects;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Channels
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Update an existing Broadcast Channels
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/update-channel" />
        [UsedImplicitly]
        public ChannelResponse UpdateChannel(UpdateChannelOptions updateChannelOptions)
        {
            return Request.ExecuteSyncRequest<ChannelResponse>(
                Config.UpdateChannelAPIPath,
                service,
                updateChannelOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Update an existing Broadcast Channels
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/update-channel" />
        [UsedImplicitly]
        public async Task<ChannelResponse> UpdateChannelAsync(UpdateChannelOptions updateChannelOptions)
        {
            return await Request.ExecuteAsyncRequest<ChannelResponse>(
                Config.UpdateChannelAPIPath,
                service,
                updateChannelOptions.BuildFormData()
            );
        }
    }
}