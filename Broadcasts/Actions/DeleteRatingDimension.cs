using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class RatingDimensions
{
    private const string DeleteDimensionAPIPath = "/channeldeleteratingsdimension.json";

    extension(BroadcastService service)
    {
        /// <summary>
        /// Delete a rating dimension for a channel
        /// </summary>
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
            return Ratings.Actions.Rating.DeleteDimension(service, DeleteDimensionAPIPath, Thing.BroadcastChannel, channelIDValidator.ReturnedObject, dimensionID);
        }

        /// <summary>
        /// Delete a rating dimension for a channel
        /// </summary>
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
            return await Ratings.Actions.Rating.DeleteDimensionAsync(service, DeleteDimensionAPIPath, Thing.BroadcastChannel, channelIDValidator.ReturnedObject, dimensionID);
        }

        /// <summary>
        /// Delete a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(
            Guid channelID,
            string dimensionID)
        {
            return Ratings.Actions.Rating.DeleteDimension(service, DeleteDimensionAPIPath, Thing.BroadcastChannel, channelID, dimensionID);
        }

        /// <summary>
        /// Delete a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteRatingDimensionAsync(
            Guid channelID,
            string dimensionID)
        {
            return await Ratings.Actions.Rating.DeleteDimensionAsync(service, DeleteDimensionAPIPath, Thing.BroadcastChannel, channelID, dimensionID);
        }

        /// <summary>
        /// Delete a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(
            Channel channel,
            string dimensionID) 
            =>
                service.DeleteRatingDimension(channel.ID, dimensionID);

        /// <summary>
        /// Delete a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteRatingDimensionAsync(
            Channel channel,
            string dimensionID) 
            =>
                await service.DeleteRatingDimensionAsync(channel.ID, dimensionID);
    }
}