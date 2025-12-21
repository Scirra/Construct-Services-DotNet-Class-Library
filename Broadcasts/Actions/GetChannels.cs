using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Get
{
    private const string GetChannelsAPIPath = "/getchannels.json";
    
    extension(BroadcastService service)
    {
        /// <summary>
        /// Get all channels in this game
        /// </summary>
        [UsedImplicitly]
        public ChannelsResponse GetChannels()
        {
            var formData = new Dictionary<string, string>();
            return Request.ExecuteSyncRequest<ChannelsResponse>(
                GetChannelsAPIPath,
                service,
                formData
            );
        }

        /// <summary>
        /// Get all channels in this game
        /// </summary>
        [UsedImplicitly]
        public async Task<ChannelsResponse> GetChannelsAsync()
        {
            var formData = new Dictionary<string, string>();
            return await Request.ExecuteAsyncRequest<ChannelsResponse>(
                GetChannelsAPIPath,
                service,
                formData
            );
        }
    }
}