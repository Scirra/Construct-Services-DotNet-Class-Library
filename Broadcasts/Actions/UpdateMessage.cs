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
    private const string UpdateMessageAPIPath = "/updatemessage.json";

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
            =>
                service.UpdateMessage(message.ID, title, text, languageISO);

        /// <summary>
        /// Update a channel message
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> UpdateMessageAsync(
            Message message,
            string title,
            string text,
            string languageISO)
            =>
                await service.UpdateMessageAsync(message.ID, title, text, languageISO);
        
        /// <summary>
        /// Update a channel message
        /// </summary>
        [UsedImplicitly]
        public BaseResponse UpdateMessage(
            string strMessageID,
            string title,
            string text,
            string languageISO)
        {
            var messageIDValidator = Common.Validations.Guid.IsValidGuid(strMessageID);
            if (!messageIDValidator.Successfull)
            {
                return new ChannelResponse(string.Format(messageIDValidator.ErrorMessage, "Message ID"), false);
            }
            return service.UpdateMessage(messageIDValidator.ReturnedObject, title, text, languageISO);
        }

        /// <summary>
        /// Update a channel message
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> UpdateMessageAsync(
            string strMessageID,
            string title,
            string text,
            string languageISO)
        {
            var messageIDValidator = Common.Validations.Guid.IsValidGuid(strMessageID);
            if (!messageIDValidator.Successfull)
            {
                return new ChannelResponse(string.Format(messageIDValidator.ErrorMessage, "Message ID"), false);
            }
            return await service.UpdateMessageAsync(messageIDValidator.ReturnedObject, title, text, languageISO);
        }

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
                { "language", languageISO }
            };

            return Request.ExecuteSyncRequest<MessageResponse>(
                UpdateMessageAPIPath,
                service,
                formData
            );
        }

        /// <summary>
        /// Update a channel message
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> UpdateMessageAsync(
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
                { "language", languageISO }
            };

            return await Request.ExecuteAsyncRequest<MessageResponse>(
                UpdateMessageAPIPath,
                service,
                formData
            );
        }
    }
}