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
    public sealed class CreateMessageOptions
    {    
        [UsedImplicitly]
        public Guid ChannelID { private get; set; }

        [UsedImplicitly]
        public string Text { private get; set; }

        [UsedImplicitly]
        public string Title { private get; set; }

        [UsedImplicitly]
        public string LanguageISO {
            private get;
            set
            {
                if (!Validations.IsValidSourceLanguage(value))
                    throw new InvalidSourceLanguageException();
                field = value;
            }
        }

        [UsedImplicitly]
        public SourceLanguage Language {
            set => LanguageISO = value.ISO();
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