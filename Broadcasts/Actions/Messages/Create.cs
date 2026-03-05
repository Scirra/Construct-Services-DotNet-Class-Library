using System;
using System.Collections.Generic;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Common.Languages;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Messages
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Creates a new Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/create-message" />
        [UsedImplicitly]
        public MessageResponse CreateMessage(CreateMessageOptions createMessageOptions)
        {
            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.EndPointPaths.Messages.Create,
                service,
                createMessageOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Creates a new Broadcast Message
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/messages/create-message" />
        [UsedImplicitly]
        public async Task<MessageResponse> CreateMessageAsync(CreateMessageOptions createMessageOptions)
        {
            return await Request.ExecuteAsyncRequest<MessageResponse>(
                Config.EndPointPaths.Messages.Create,
                service,
                createMessageOptions.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class CreateMessageOptions(
        Guid channelID,
        string title,
        string text)
    {    
        private Guid ChannelID { get; } = channelID;
        private string Text { get;  } = text;

        [UsedImplicitly]
        public string Title { private get; set; } = title;

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
        public CreateMessageOptions(
            Guid channelID,
            string text) : this(channelID, null, text)
        {
        }
        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", ChannelID.ToString() },
                { "title", Title },
                { "text", Text },
                { "language", LanguageISO }
            };
            return formData;
        }
    }

}