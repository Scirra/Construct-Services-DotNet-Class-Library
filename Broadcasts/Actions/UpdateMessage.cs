using ConstructServices.Broadcasts.Objects;
using ConstructServices.Broadcasts.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Update
{    
    extension(BroadcastService service)
    {
        /// <summary>
        /// Update a channel message
        /// </summary>
        [UsedImplicitly]
        public BaseResponse UpdateMessage(
            Message message,
            string title,
            string text,
            string languageISO)
            => UpdateMessage(service, message.ID, title, text, languageISO);

        /// <summary>
        /// Update a channel message
        /// </summary>
        [UsedImplicitly]
        public BaseResponse UpdateMessage(
            Guid messageID,
            string title,
            string text,
            string languageISO)
        {
            var formData = new Dictionary<string, string>
            {
                { "messageID", messageID.ToString() },
                { "title", title },
                { "text", text },
                { "language", languageISO },
            };

            const string path = "/updatemessage.json";
            return Task.Run(() => Request.ExecuteRequest<MessageResponse>(
                path,
                service,
                formData
            )).Result;
        }
    }
}