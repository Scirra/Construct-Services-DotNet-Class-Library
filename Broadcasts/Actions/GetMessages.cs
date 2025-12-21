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
    private const string GetMessagesAPIPath = "/getmessages.json";

    extension(BroadcastService service)
    {
        /// <summary>
        /// Get multiple messages in a channel
        /// </summary>
        [UsedImplicitly]
        public MessagesResponse GetMessages(
            Channel channel, 
            PaginationOptions paginationOptions)
            =>
                service.GetMessages(channel.ID, paginationOptions);

        /// <summary>
        /// Get multiple messages in a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<MessagesResponse> GetMessagesAsync(
            Channel channel, 
            PaginationOptions paginationOptions)
            =>
                await service.GetMessagesAsync(channel.ID, paginationOptions);

        /// <summary>
        /// Get multiple messages in a channel
        /// </summary>
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

        /// <summary>
        /// Get multiple messages in a channel
        /// </summary>
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

            return Request.ExecuteSyncRequest<MessagesResponse>(
                GetMessagesAPIPath,
                service,
                formData,
                paginationOptions
            );
        }

        /// <summary>
        /// Get multiple messages in a channel
        /// </summary>
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
                GetMessagesAPIPath,
                service,
                formData,
                paginationOptions
            );
        }
    }
}