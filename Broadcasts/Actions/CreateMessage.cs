using ConstructServices.Broadcasts.Objects;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Create
{
    private const string CreateMessageAPIPath = "/createmessage.json";

    extension(BroadcastService service)
    {
        /// <summary>
        /// Create a new message in a channel
        /// </summary>
        [UsedImplicitly]
        public MessageResponse CreateMessage(
            Channel channel,
            string title,
            string text,
            string languageISO) =>
            service.CreateMessage(channel.ID, title, text, languageISO);

        /// <summary>
        /// Create a new message in a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<MessageResponse> CreateMessageAsync(
            Channel channel,
            string title,
            string text,
            string languageISO) =>
            await service.CreateMessageAsync(channel.ID, title, text, languageISO);
        
        /// <summary>
        /// Create a new message in a channel
        /// </summary>
        [UsedImplicitly]
        public MessageResponse CreateMessage(
            string strChannelID,
            string title,
            string text,
            string languageISO)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new MessageResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"), false);
            }
            return service.CreateMessage(channelIDValidator.ReturnedObject, title, text, languageISO);
        }

        /// <summary>
        /// Create a new message in a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<MessageResponse> CreateMessageAsync(
            string strChannelID,
            string title,
            string text,
            string languageISO)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new MessageResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"), false);
            }
            return await service.CreateMessageAsync(channelIDValidator.ReturnedObject, title, text, languageISO);
        }

        /// <summary>
        /// Create a new message in a channel
        /// </summary>
        [UsedImplicitly]
        public MessageResponse CreateMessage(
            Guid channelID,
            string title,
            string text,
            string languageISO)
        {
            var textValidator = Common.Validations.BroadcastMessageText.ValidateTest(text);
            if (!textValidator.Successfull)
            {
                return new MessageResponse(textValidator.ErrorMessage, false);
            }

            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() },
                { "title", title },
                { "text", text },
                { "language", languageISO }
            };

            return Request.ExecuteSyncRequest<MessageResponse>(
                CreateMessageAPIPath,
                service,
                formData
            );
        }

        /// <summary>
        /// Create a new message in a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<MessageResponse> CreateMessageAsync(
            Guid channelID,
            string title,
            string text,
            string languageISO)
        {
            var textValidator = Common.Validations.BroadcastMessageText.ValidateTest(text);
            if (!textValidator.Successfull)
            {
                return new MessageResponse(textValidator.ErrorMessage, false);
            }

            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() },
                { "title", title },
                { "text", text },
                { "language", languageISO }
            };

            return await Request.ExecuteAsyncRequest<MessageResponse>(
                CreateMessageAPIPath,
                service,
                formData
            );
        }
    }
}