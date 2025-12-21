using System;
using System.Threading.Tasks;
using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;

namespace ConstructServices.Broadcasts.Actions;

public static partial class RatingDimensions
{
    private const string EditDimensionAPIPath = "/channeleditratingdimension.json";

    extension(BroadcastService service)
    {
        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse EditRatingDimension(
            Guid channelID,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
        {
            return Ratings.Actions.Rating.EditDimension(service, EditDimensionAPIPath, Thing.CloudSaveBlob, channelID, dimensionID, newTitle, newDescription, newMaxRating, newLanguageISO);
        }        
        
        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse EditRatingDimension(
            string strChannelID,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new DimensionResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return Ratings.Actions.Rating.EditDimension(service, EditDimensionAPIPath, Thing.CloudSaveBlob, channelIDValidator.ReturnedObject, dimensionID, newTitle, newDescription, newMaxRating, newLanguageISO);
        }

        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> EditRatingDimensionAsync(
            Guid channelID,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
        {
            return await Ratings.Actions.Rating.EditDimensionAsync(service, EditDimensionAPIPath, Thing.CloudSaveBlob, channelID, dimensionID, newTitle, newDescription, newMaxRating, newLanguageISO);
        }

        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> EditRatingDimensionAsync(
            string strChannelID,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new DimensionResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return await Ratings.Actions.Rating.EditDimensionAsync(service, EditDimensionAPIPath, Thing.CloudSaveBlob, channelIDValidator.ReturnedObject, dimensionID, newTitle, newDescription, newMaxRating, newLanguageISO);
        }

        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse EditRatingDimension(Channel channel,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
            =>
                service.EditRatingDimension(channel.ID, dimensionID, newTitle, newDescription, newMaxRating, newLanguageISO);

        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> EditRatingDimensionAsync(Channel channel,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
            =>
                await service.EditRatingDimensionAsync(channel.ID, dimensionID, newTitle, newDescription, newMaxRating, newLanguageISO);
    }
}