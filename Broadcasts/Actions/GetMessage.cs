using ConstructServices.Broadcasts.Objects;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Get
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Delete a message
        /// </summary>
        [UsedImplicitly]
        public MessageResponse GetMessage(
            Message message)
            =>
                service.GetMessage(message.ID);

        /// <summary>
        /// Delete a message
        /// </summary>
        [UsedImplicitly]
        public MessageResponse GetMessage(
            Guid messageID)
        {
            var formData = new Dictionary<string, string>
            {
                { "messageID", messageID.ToString() }
            };

            const string path = "/getmessage.json";
            return Request.ExecuteSyncRequest<MessageResponse>(
                path,
                service,
                formData
            );
        }
    }
}