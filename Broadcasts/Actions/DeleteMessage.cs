using ConstructServices.Broadcasts.Objects;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static class Delete
{
    extension(BroadcastService service)
    {
        [UsedImplicitly]
        public BaseResponse DeleteMessage(
            Message message)
            =>
                service.DeleteMessage(message.ID);

        [UsedImplicitly]
        public async Task<BaseResponse> DeleteMessageAsync(
            Message message)
            =>
                await service.DeleteMessageAsync(message.ID);

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

        [UsedImplicitly]
        public BaseResponse DeleteMessage(
            Guid messageID)
        {
            var formData = new Dictionary<string, string>
            {
                { "messageID", messageID.ToString() }
            };

            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.DeleteMessageAPIPath,
                service,
                formData
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> DeleteMessageAsync(
            Guid messageID)
        {
            var formData = new Dictionary<string, string>
            {
                { "messageID", messageID.ToString() }
            };

            return await Request.ExecuteAsyncRequest<MessageResponse>(
                Config.DeleteMessageAPIPath,
                service,
                formData
            );
        }
    }
}