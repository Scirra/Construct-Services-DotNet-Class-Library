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
        public BaseResponse DeleteChannel(DeleteChannelOptions deleteChannelOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Channels.Delete,
                service,
                deleteChannelOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Delete an existing Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/delete-channel" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteChannelAsync(DeleteChannelOptions deleteChannelOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Channels.Delete,
                service,
                deleteChannelOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class DeleteChannelOptions
    {
        private Guid ChannelID { get; }
    
        public DeleteChannelOptions(string strChannelID)
        {
            ChannelID = Guid.Parse(strChannelID);
        }
        public DeleteChannelOptions(Guid channelID)
        {
            ChannelID = channelID;
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", ChannelID.ToString() }
            };
            return formData;
        }
    }
}