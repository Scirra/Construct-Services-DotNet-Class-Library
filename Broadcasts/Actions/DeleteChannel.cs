using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

internal static partial class Delete
{
    private const string DeleteChannelAPIPath = "/deletechannel.json";

    extension(BroadcastService service)
    {
        /// <summary>
        /// Delete existing channel
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteChannel(Channel channel)
            => service.DeleteChannel(channel.ID);

        /// <summary>
        /// Delete existing channel
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteChannelAsync(Channel channel)
            => await service.DeleteChannelAsync(channel.ID);
        
        /// <summary>
        /// Delete existing channel
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteChannel(string strChannelID)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new DimensionResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }

            return service.DeleteChannel(channelIDValidator.ReturnedObject);
        }

        /// <summary>
        /// Delete existing channel
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteChannelAsync(string strChannelID)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new DimensionResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }

            return await service.DeleteChannelAsync(channelIDValidator.ReturnedObject);
        }

        /// <summary>
        /// Delete existing channel
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteChannel(Guid channelID)
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() }
            };

            return Request.ExecuteSyncRequest<BaseResponse>(
                DeleteChannelAPIPath,
                service,
                formData
            );
        }

        /// <summary>
        /// Delete existing channel
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteChannelAsync(Guid channelID)
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() }
            };

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                DeleteChannelAPIPath,
                service,
                formData
            );
        }
    }
}