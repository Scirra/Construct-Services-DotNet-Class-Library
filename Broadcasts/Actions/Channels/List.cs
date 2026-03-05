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
        /// List all Broadcast Channels
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/list-channels" />
        [UsedImplicitly]
        public ChannelsResponse ListChannels()
        {
            return Request.ExecuteSyncRequest<ChannelsResponse>(
                Config.EndPointPaths.Channels.List,
                service
            );
        }

        /// <summary>
        /// List all Broadcast Channels
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/list-channels" />
        [UsedImplicitly]
        public async Task<ChannelsResponse> ListChannelsAsync()
        {
            return await Request.ExecuteAsyncRequest<ChannelsResponse>(
                Config.EndPointPaths.Channels.List,
                service
            );
        }
    }
}