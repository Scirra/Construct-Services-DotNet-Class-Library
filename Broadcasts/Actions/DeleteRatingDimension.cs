using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class RatingDimensions
{
    extension(BroadcastService service)
    {
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(
            string strChannelID,
            string dimensionID)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new DimensionResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return Ratings.Actions.Rating.DeleteDimension(service, Config.DeleteDimensionAPIPath, Thing.BroadcastChannel, channelIDValidator.ReturnedObject, dimensionID);
        }

        [UsedImplicitly]
        public async Task<BaseResponse> DeleteRatingDimensionAsync(
            string strChannelID,
            string dimensionID)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new DimensionResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return await Ratings.Actions.Rating.DeleteDimensionAsync(service, Config.DeleteDimensionAPIPath, Thing.BroadcastChannel, channelIDValidator.ReturnedObject, dimensionID);
        }

        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(
            Guid channelID,
            string dimensionID)
        {
            return Ratings.Actions.Rating.DeleteDimension(service, Config.DeleteDimensionAPIPath, Thing.BroadcastChannel, channelID, dimensionID);
        }

        [UsedImplicitly]
        public async Task<BaseResponse> DeleteRatingDimensionAsync(
            Guid channelID,
            string dimensionID)
        {
            return await Ratings.Actions.Rating.DeleteDimensionAsync(service, Config.DeleteDimensionAPIPath, Thing.BroadcastChannel, channelID, dimensionID);
        }

        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(
            Channel channel,
            string dimensionID) 
            =>
                service.DeleteRatingDimension(channel.ID, dimensionID);

        [UsedImplicitly]
        public async Task<BaseResponse> DeleteRatingDimensionAsync(
            Channel channel,
            string dimensionID) 
            =>
                await service.DeleteRatingDimensionAsync(channel.ID, dimensionID);
    }
}