using System;
using System.Collections.Generic;
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
                Config.EndPointPaths.Channels.Update,
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
                Config.EndPointPaths.Channels.Update,
                service,
                updateChannelOptions.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class UpdateChannelOptions
    {    
        private Guid ID { get; [UsedImplicitly] set; }
        public string Name { get; [UsedImplicitly] set; }
        public string Description { get; [UsedImplicitly] set; }
        public string LanguageISO { get; [UsedImplicitly] set; }
        public bool? AllowRatings { get; [UsedImplicitly] set; }
    
        public UpdateChannelOptions(Guid channelID)
        {
            ID = channelID;
        }
        public UpdateChannelOptions(string strChannelID)
        {
            ID = Guid.Parse(strChannelID);
        }
        internal Dictionary<string, string> BuildFormData()
        {        
            var formData = new Dictionary<string, string>
            {
                { "channelID", ID.ToString() },
                { "name", Name },
                { "description", Description },
                { "language", LanguageISO }
            };
            if(AllowRatings.HasValue) formData.Add("allowRatings", AllowRatings.Value.ToInt().ToString());
            return formData;
        }
    }
}