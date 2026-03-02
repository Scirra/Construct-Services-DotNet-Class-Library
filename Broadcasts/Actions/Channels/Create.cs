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
        /// Creates a new Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/channels/create-channel" />
        [UsedImplicitly]
        public ChannelResponse CreateChannel(CreateChannelOptions createChannelOptions)
        {
            return Request.ExecuteSyncRequest<ChannelResponse>(
                Config.EndPointPaths.Channels.Create,
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
                Config.EndPointPaths.Channels.Create,
                service,
                createChannelOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class CreateChannelOptions(
        string name,
        string description,
        bool allowRatings,
        string languageISO = null)
    {    
        private string Name { get; } = name;
        private string Description { get; } = description;
        private string LanguageISO { get; } = languageISO;
        private bool AllowRatings { get; } = allowRatings;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "name", Name },
                { "description", Description },
                { "language", LanguageISO },
                { "allowRatings", AllowRatings.ToInt().ToString() }
            };
            return formData;
        }
    }
}