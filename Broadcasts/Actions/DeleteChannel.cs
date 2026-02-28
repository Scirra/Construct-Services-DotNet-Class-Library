using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Delete
{
    extension(BroadcastService service)
    {
        [UsedImplicitly]
        public BaseResponse DeleteChannel(Channel channel)
            => service.DeleteChannel(channel.ID);

        [UsedImplicitly]
        public async Task<BaseResponse> DeleteChannelAsync(Channel channel)
            => await service.DeleteChannelAsync(channel.ID);
        
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

        [UsedImplicitly]
        public BaseResponse DeleteChannel(Guid channelID)
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() }
            };

            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.DeleteChannelAPIPath,
                service,
                formData
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> DeleteChannelAsync(Guid channelID)
        {
            var formData = new Dictionary<string, string>
            {
                { "channelID", channelID.ToString() }
            };

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.DeleteChannelAPIPath,
                service,
                formData
            );
        }
    }
}