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
    extension(BroadcastService service)
    {
        [UsedImplicitly]
        public MessageResponse CreateMessage(
            Channel channel,
            string title,
            string text,
            string languageISO) =>
            service.CreateMessage(channel.ID, title, text, languageISO);

        [UsedImplicitly]
        public async Task<MessageResponse> CreateMessageAsync(
            Channel channel,
            string title,
            string text,
            string languageISO) =>
            await service.CreateMessageAsync(channel.ID, title, text, languageISO);
        
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
                return new MessageResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return service.CreateMessage(channelIDValidator.ReturnedObject, title, text, languageISO);
        }

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
                return new MessageResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return await service.CreateMessageAsync(channelIDValidator.ReturnedObject, title, text, languageISO);
        }

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
                return new MessageResponse(textValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() },
                { "title", title },
                { "text", text },
                { "language", languageISO }
            };

            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.CreateMessageAPIPath,
                service,
                formData
            );
        }

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
                return new MessageResponse(textValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() },
                { "title", title },
                { "text", text },
                { "language", languageISO }
            };

            return await Request.ExecuteAsyncRequest<MessageResponse>(
                Config.CreateMessageAPIPath,
                service,
                formData
            );
        }
    }
}