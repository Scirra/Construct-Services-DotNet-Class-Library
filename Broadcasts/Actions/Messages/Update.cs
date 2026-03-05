using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using ConstructServices.Common.Languages;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Functions = ConstructServices.Common.Validations.Common.Functions;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Messages
{    
    extension(BroadcastService service)
    {
        /// <summary>
        /// Update an existing Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/update-message" />
        [UsedImplicitly]
        public BaseResponse UpdateMessage(Guid messageID, UpdateMessageOptions updateMessageOptions)
        {
            var validation = updateMessageOptions.Validate();
            if (!validation.Valid) return new BaseResponse(validation.ErrorMessage);

            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.EndPointPaths.Messages.Update,
                service,
                updateMessageOptions.BuildFormData(messageID)
            );
        }

        /// <summary>
        /// Update an existing Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/update-message" />
        [UsedImplicitly]
        public async Task<BaseResponse> UpdateMessageAsync(Guid messageID, UpdateMessageOptions updateMessageOptions)
        {
            var validation = updateMessageOptions.Validate();
            if (!validation.Valid) return new BaseResponse(validation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<MessageResponse>(
                Config.EndPointPaths.Messages.Update,
                service,
                updateMessageOptions.BuildFormData(messageID)
            );
        }
    }

    [UsedImplicitly]
    public sealed class UpdateMessageOptions
    {
        [UsedImplicitly]
        public string Title { private get; set; }

        [UsedImplicitly]
        public string Text { private get; set; }
        
        [UsedImplicitly]
        public string LanguageISO { private get; set; }

        [UsedImplicitly]
        public SourceLanguage Language {
            set => LanguageISO = value.ISO();
        }

        internal Common.Validations.Responses.ValidationResponseBase Validate()
        {
            var textValidation = Common.Validations.Broadcasts.Functions.IsMessageTextValid(Text);
            if (!textValidation.Valid) return textValidation;

            var languageValidation = Functions.IsSourceLanguageISOValid(LanguageISO, true);
            if (!languageValidation.Valid) return languageValidation;

            return new Common.Validations.Responses.SuccessfullValidation();
        }

        internal Dictionary<string, string> BuildFormData(Guid messageID)
        {
            var formData = new Dictionary<string, string>
            {
                { "messageID", messageID.ToString() },
                { "title", Title },
                { "text", Text },
                { "language", LanguageISO }
            };
            return formData;
        }
    }
}