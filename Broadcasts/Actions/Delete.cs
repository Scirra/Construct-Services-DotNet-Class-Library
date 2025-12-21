using ConstructServices.Broadcasts.Objects;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace ConstructServices.Broadcasts.Actions;

public static class Delete
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Delete a message
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteMessage(
            Message message)
            =>
                service.DeleteMessage(message.ID);

        /// <summary>
        /// Delete a message
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteMessage(
            Guid messageID)
        {
            var formData = new Dictionary<string, string>
            {
                { "messageID", messageID.ToString() }
            };

            const string path = "/deletemessage.json";
            return Request.ExecuteSyncRequest<MessageResponse>(
                path,
                service,
                formData
            );
        }

        /// <summary>
        /// Create a new channel
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteChannel(Guid channelID)
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() }
            };

            const string path = "/deletechannel.json";
            return Request.ExecuteSyncRequest<BaseResponse>(
                path,
                service,
                formData
            );
        }
    }
}