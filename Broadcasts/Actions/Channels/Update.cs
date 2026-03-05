using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using ConstructServices.Common.Languages;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
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
        public ChannelResponse UpdateChannel(Guid channelID, UpdateChannelOptions updateChannelOptions)
        {
            return Request.ExecuteSyncRequest<ChannelResponse>(
                Config.EndPointPaths.Channels.Update,
                service,
                updateChannelOptions.BuildFormData(channelID)
            );
        }

        /// <summary>
        /// Update an existing Broadcast Channels
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/update-channel" />
        [UsedImplicitly]
        public async Task<ChannelResponse> UpdateChannelAsync(Guid channelID, UpdateChannelOptions updateChannelOptions)
        {
            return await Request.ExecuteAsyncRequest<ChannelResponse>(
                Config.EndPointPaths.Channels.Update,
                service,
                updateChannelOptions.BuildFormData(channelID)
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class UpdateChannelOptions
    {    
        [UsedImplicitly]
        public string Name { private get; set; }

        [UsedImplicitly]
        public string Description { private get; set; }

        [UsedImplicitly]
        public string LanguageISO {
            private get;
            set
            {
                if (!Common.Validations.Languages.IsValidSourceLanguage(value))
                    throw new InvalidSourceLanguageException();
                field = value;
            }
        }

        [UsedImplicitly]
        public SourceLanguage Language {
            set => LanguageISO = value.ISO();
        }

        [UsedImplicitly]
        public bool? AllowRatings { private get; set; }
    
        internal Dictionary<string, string> BuildFormData(Guid channelID)
        {        
            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() },
                { "name", Name },
                { "description", Description },
                { "language", LanguageISO }
            };
            if(AllowRatings.HasValue) formData.Add("allowRatings", AllowRatings.Value.ToInt().ToString());
            return formData;
        }
    }
}