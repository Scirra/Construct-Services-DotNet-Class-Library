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

    extension(BroadcastService service)
    {
        [UsedImplicitly]
        public MessagesResponse GetMessages(
            Channel channel, 
            PaginationOptions paginationOptions)
            =>
                service.GetMessages(channel.ID, paginationOptions);

        [UsedImplicitly]
        public async Task<MessagesResponse> GetMessagesAsync(
            Channel channel, 
            PaginationOptions paginationOptions)
            =>
                await service.GetMessagesAsync(channel.ID, paginationOptions);

        [UsedImplicitly]
        public MessagesResponse GetMessages(
            string strChannelID,
            PaginationOptions paginationOptions)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new MessagesResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return service.GetMessages(channelIDValidator.ReturnedObject, paginationOptions);
        }

        [UsedImplicitly]
        public async Task<MessagesResponse> GetMessagesAsync(
            string strChannelID,
            PaginationOptions paginationOptions)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new MessagesResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return await service.GetMessagesAsync(channelIDValidator.ReturnedObject, paginationOptions);
        }

        [UsedImplicitly]
        public MessagesResponse GetMessages(
            Guid channelID,
            PaginationOptions paginationOptions)
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() }
            };

            return Request.ExecuteSyncRequest<MessagesResponse>(
                Config.GetMessagesAPIPath,
                service,
                formData,
                paginationOptions
            );
        }

        [UsedImplicitly]
        public async Task<MessagesResponse> GetMessagesAsync(
            Guid channelID,
            PaginationOptions paginationOptions)
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() }
            };

            return await Request.ExecuteAsyncRequest<MessagesResponse>(
                Config.GetMessagesAPIPath,
                service,
                formData,
                paginationOptions
            );
        }
    }
}