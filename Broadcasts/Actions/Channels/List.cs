using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Channels
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// List all Broadcast Channels
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/list-channels" />
        [UsedImplicitly]
        public ChannelsResponse ListChannels()
        {
            var formData = new Dictionary<string, string>();
            return Request.ExecuteSyncRequest<ChannelsResponse>(
                Config.GetChannelsAPIPath,
                service,
                formData
            );
        }

        /// <summary>
        /// List all Broadcast Channels
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/list-channels" />
        [UsedImplicitly]
        public async Task<ChannelsResponse> ListChannelsAsync()
        {
            var formData = new Dictionary<string, string>();
            return await Request.ExecuteAsyncRequest<ChannelsResponse>(
                Config.GetChannelsAPIPath,
                service,
                formData
            );
        }
    }
}