using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Broadcasts.Objects;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Create
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Create a new message in a channel
        /// </summary>
        [UsedImplicitly]
        public MessageResponse CreateMessage(
            Channel channel,
            string title,
            string text,
            string languageISO)
            => CreateMessage(service, channel.ID, title, text, languageISO);

        /// <summary>
        /// Create a new message in a channel
        /// </summary>
        [UsedImplicitly]
        public MessageResponse CreateMessage(
            Guid channelID,
            string title,
            string text,
            string languageISO)
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() },
                { "title", title },
                { "text", text },
                { "language", languageISO },
            };

            const string path = "/createmessage.json";
            return Request.ExecuteSyncRequest<MessageResponse>(
                path,
                service,
                formData
            );
        }
    }
}