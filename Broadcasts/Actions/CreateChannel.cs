using ConstructServices.Broadcasts.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Create
{
    private const string CreateChannelAPIPath = "/createchannel.json";
    
    extension(BroadcastService service)
    {
        /// <summary>
        /// Create a new channel
        /// </summary>
        [UsedImplicitly]
        public ChannelResponse CreateChannel(
            string channelName,
            string channelDescription,
            string languageISO,
            bool allowRatings)
        {
            var nameValidator = Common.Validations.ChannelName.ValidateChannelName(channelName);
            if (!nameValidator.Successfull)
            {
                return new ChannelResponse(nameValidator.ErrorMessage, false);
            }

            var formData = new Dictionary<string, string>
            {
                { "name", channelName },
                { "description", channelDescription },
                { "language", languageISO },
                { "allowRatings", allowRatings.ToInt().ToString() }
            };

            return Request.ExecuteSyncRequest<ChannelResponse>(
                CreateChannelAPIPath,
                service,
                formData
            );
        }

        /// <summary>
        /// Create a new channel
        /// </summary>
        [UsedImplicitly]
        public async Task<ChannelResponse> CreateChannelAsync(
            string channelName,
            string channelDescription,
            string languageISO,
            bool allowRatings)
        {
            var nameValidator = Common.Validations.ChannelName.ValidateChannelName(channelName);
            if (!nameValidator.Successfull)
            {
                return new ChannelResponse(nameValidator.ErrorMessage, false);
            }

            var formData = new Dictionary<string, string>
            {
                { "name", channelName },
                { "description", channelDescription },
                { "language", languageISO },
                { "allowRatings", allowRatings.ToInt().ToString() }
            };

            return await Request.ExecuteAsyncRequest<ChannelResponse>(
                CreateChannelAPIPath,
                service,
                formData
            );
        }
    }
}