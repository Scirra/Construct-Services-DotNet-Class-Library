using ConstructServices.Broadcasts.Objects;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

internal static partial class Delete
{
    private const string DeleteMessageAPIPath = "/deletemessage.json";

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
        public async Task<BaseResponse> DeleteMessageAsync(
            Message message)
            =>
                await service.DeleteMessageAsync(message.ID);

        /// <summary>
        /// Delete a message
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteMessage(
            string strMessageID)
        {
            var messageIDValidator = Common.Validations.Guid.IsValidGuid(strMessageID);
            if (!messageIDValidator.Successfull)
            {
                return new DimensionResponse(string.Format(messageIDValidator.ErrorMessage, "Message ID"));
            }
            return service.DeleteMessage(messageIDValidator.ReturnedObject);
        }

        /// <summary>
        /// Delete a message
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteMessageAsync(
            string strMessageID)
        {
            var messageIDValidator = Common.Validations.Guid.IsValidGuid(strMessageID);
            if (!messageIDValidator.Successfull)
            {
                return new DimensionResponse(string.Format(messageIDValidator.ErrorMessage, "Message ID"));
            }
            return await service.DeleteMessageAsync(messageIDValidator.ReturnedObject);
        }

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

            return Request.ExecuteSyncRequest<MessageResponse>(
                DeleteMessageAPIPath,
                service,
                formData
            );
        }

        /// <summary>
        /// Delete a message
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteMessageAsync(
            Guid messageID)
        {
            var formData = new Dictionary<string, string>
            {
                { "messageID", messageID.ToString() }
            };

            return await Request.ExecuteAsyncRequest<MessageResponse>(
                DeleteMessageAPIPath,
                service,
                formData
            );
        }
    }
}