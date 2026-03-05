using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using ConstructServices.Common.Languages;
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
    public sealed class CreateChannelOptions(string name)
    {
        private string Name { get; } = name;

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
        public bool AllowRatings { private get; set; }

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