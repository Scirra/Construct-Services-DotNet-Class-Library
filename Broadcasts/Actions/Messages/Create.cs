using System;
using System.Collections.Generic;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

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
        private Guid ChannelID { get; }
        private string Text { get;  }

        [UsedImplicitly]
        public string Title { private get; set; }

        [UsedImplicitly]
        public string LanguageISO { private get; set; }
    
        public CreateMessageOptions(
            Guid channelID,
            string text)
        {
            ChannelID = channelID;
            Text = text;
        }
        public CreateMessageOptions(
            Guid channelID,
            string title,
            string text)
        {
            ChannelID = channelID;
            Title = title;
            Text = text;
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