using ConstructServices.Broadcasts.Objects;
using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Update
{

    extension(BroadcastService service)
    {
        [UsedImplicitly]
        public ChannelResponse UpdateChannel(
            string strChannelID,
            string channelName,
            string channelDescription,
            string languageISO,
            bool allowRatings)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new ChannelResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return service.UpdateChannel(channelIDValidator.ReturnedObject, channelName, channelDescription, languageISO, allowRatings);
        }

        [UsedImplicitly]
        public async Task<ChannelResponse> UpdateChannelAsync(
            string strChannelID,
            string channelName,
            string channelDescription,
            string languageISO,
            bool allowRatings)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new ChannelResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return await service.UpdateChannelAsync(channelIDValidator.ReturnedObject, channelName, channelDescription, languageISO, allowRatings);
        }
        
        [UsedImplicitly]
        public ChannelResponse UpdateChannel(
            Channel channel,
            string channelName,
            string channelDescription,
            string languageISO,
            bool allowRatings)
            =>
                service.UpdateChannel(channel.ID, channelName, channelDescription, languageISO, allowRatings);

        [UsedImplicitly]
        public async Task<ChannelResponse> UpdateChannelAsync(
            Channel channel,
            string channelName,
            string channelDescription,
            string languageISO,
            bool allowRatings)
            =>
                await service.UpdateChannelAsync(channel.ID, channelName, channelDescription, languageISO, allowRatings);

        [UsedImplicitly]
        public ChannelResponse UpdateChannel(
            Guid channelID,
            string channelName,
            string channelDescription,
            string languageISO,
            bool allowRatings)
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() },
                { "name", channelName },
                { "description", channelDescription },
                { "language", languageISO },
                { "allowRatings", allowRatings.ToInt().ToString() }
            };

            return Request.ExecuteSyncRequest<ChannelResponse>(
                Config.UpdateChannelAPIPath,
                service,
                formData
            );
        }

        [UsedImplicitly]
        public async Task<ChannelResponse> UpdateChannelAsync(
            Guid channelID,
            string channelName,
            string channelDescription,
            string languageISO,
            bool allowRatings)
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() },
                { "name", channelName },
                { "description", channelDescription },
                { "language", languageISO },
                { "allowRatings", allowRatings.ToInt().ToString() }
            };

            return await Request.ExecuteAsyncRequest<ChannelResponse>(
                Config.UpdateChannelAPIPath,
                service,
                formData
            );
        }
    }
}