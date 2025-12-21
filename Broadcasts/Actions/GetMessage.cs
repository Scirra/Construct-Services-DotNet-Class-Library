using ConstructServices.Broadcasts.Objects;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Get
{
    private const string GetMessageAPIPath = "/getmessage.json";

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
        public async Task<MessageResponse> GetMessageAsync(
            Message message)
            =>
               await service.GetMessageAsync(message.ID);

        /// <summary>
        /// Delete a message
        /// </summary>
        [UsedImplicitly]
        public MessageResponse GetMessage(
            string strMessageID)
        {
            var messageIDValidator = Common.Validations.Guid.IsValidGuid(strMessageID);
            if (!messageIDValidator.Successfull)
            {
                return new MessageResponse(string.Format(messageIDValidator.ErrorMessage, "Message ID"));
            }
            return service.GetMessage(messageIDValidator.ReturnedObject);
        }

        /// <summary>
        /// Delete a message
        /// </summary>
        [UsedImplicitly]
        public async Task<MessageResponse> GetMessageAsync(
            string strMessageID)
        {
            var messageIDValidator = Common.Validations.Guid.IsValidGuid(strMessageID);
            if (!messageIDValidator.Successfull)
            {
                return new MessageResponse(string.Format(messageIDValidator.ErrorMessage, "Message ID"));
            }
            return await service.GetMessageAsync(messageIDValidator.ReturnedObject);
        }

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

            return Request.ExecuteSyncRequest<MessageResponse>(
                GetMessageAPIPath,
                service,
                formData
            );
        }

        /// <summary>
        /// Delete a message
        /// </summary>
        [UsedImplicitly]
        public async Task<MessageResponse> GetMessageAsync(
            Guid messageID)
        {
            var formData = new Dictionary<string, string>
            {
                { "messageID", messageID.ToString() }
            };

            return await Request.ExecuteAsyncRequest<MessageResponse>(
                GetMessageAPIPath,
                service,
                formData
            );
        }
    }
}