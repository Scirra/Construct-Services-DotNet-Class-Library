using System;
using System.Collections.Generic;
using ConstructServices.Broadcasts.Objects;
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
        private string Title { get; }
        private string Text { get;  }
        private string LanguageISO { get; }
        private Guid ChannelID { get; }
    
        public CreateMessageOptions(
            Guid channelID,
            string title,
            string text,
            string languageISO = null)
        {
            ChannelID = channelID;
            Title = title;
            Text = text;
            LanguageISO = languageISO;
        }
        public CreateMessageOptions(
            string strChannelID,
            string title,
            string text,
            string languageISO = null)
        {
            ChannelID = Guid.Parse(strChannelID);
            Title = title;
            Text = text;
            LanguageISO = languageISO;
        }
        public CreateMessageOptions(
            Channel channel,
            string title,
            string text,
            string languageISO = null)
        {
            ChannelID = channel.ID;
            Title = title;
            Text = text;
            LanguageISO = languageISO;
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