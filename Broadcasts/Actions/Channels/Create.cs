using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using ConstructServices.Common.Languages;
using JetBrains.Annotations;
using Functions = ConstructServices.Common.Validations.Common.Functions;

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
            var validation = createChannelOptions.Validate();
            if (!validation.Valid) return new ChannelResponse(validation.ErrorMessage);

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
            var validation = createChannelOptions.Validate();
            if (!validation.Valid) return new ChannelResponse(validation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<ChannelResponse>(
                Config.EndPointPaths.Channels.Create,
                service,
                createChannelOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class CreateChannelOptions
    {
        [UsedImplicitly]
        public string Name { private get; set; }

        [UsedImplicitly]
        public string Description { private get; set; }
        
        [UsedImplicitly]
        public string LanguageISO { private get; set; }

        [UsedImplicitly]
        public SourceLanguage Language {
            set => LanguageISO = value.ISO();
        }

        [UsedImplicitly]
        public bool AllowRatings { private get; set; }

        internal Common.Validations.Responses.ValidationResponseBase Validate()
        {
            var nameValidation = Common.Validations.Broadcasts.Functions.IsChannelNameValid(Name);
            if (!nameValidation.Valid) return nameValidation;

            var languageValidation = Functions.IsSourceLanguageISOValid(LanguageISO, true);
            if (!languageValidation.Valid) return languageValidation;

            return new Common.Validations.Responses.SuccessfullValidation();
        }

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