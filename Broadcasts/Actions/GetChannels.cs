using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Get
{

    extension(BroadcastService service)
    {
        [UsedImplicitly]
        public ChannelsResponse GetChannels()
        {
            var formData = new Dictionary<string, string>();
            return Request.ExecuteSyncRequest<ChannelsResponse>(
                Config.GetChannelsAPIPath,
                service,
                formData
            );
        }

        [UsedImplicitly]
        public async Task<ChannelsResponse> GetChannelsAsync()
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