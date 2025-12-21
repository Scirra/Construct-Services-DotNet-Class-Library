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
        /// Get multiple messages in a channel
        /// </summary>
        [UsedImplicitly]
        public MessagesResponse GetMessages(
            Channel channel, PaginationOptions paginationOptions)
            =>
                service.GetMessages(channel.ID, paginationOptions);

        /// <summary>
        /// Get multiple messages in a channel
        /// </summary>
        [UsedImplicitly]
        public MessagesResponse GetMessages(
            Guid channelID,
            PaginationOptions paginationOptions)
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() }
            };

            const string path = "/getmessages.json";
            return Request.ExecuteSyncRequest<MessagesResponse>(
                path,
                service,
                formData,
                paginationOptions
            );
        }
    }
}