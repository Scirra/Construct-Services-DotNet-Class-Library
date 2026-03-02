using System;
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
        /// Get an existing Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/get-channel" />
        [UsedImplicitly]
        public ChannelResponse GetChannel(GetChannelOptions getChannelOptions)
        {
            return Request.ExecuteSyncRequest<ChannelResponse>(
                Config.EndPointPaths.Channels.Get,
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
                Config.EndPointPaths.Channels.Get,
                service,
                getChannelOptions.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class GetChannelOptions(string sessionKey, Guid channelID)
    {
        private string SessionKey { get; } = sessionKey;
        private Guid ChannelID { get; } = channelID;

        public GetChannelOptions(Guid channelID) : this(null, channelID)
        {
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", ChannelID.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(SessionKey))
            {
                formData.Add("sessionKey", SessionKey);
            }
            return formData;
        }
    }
}