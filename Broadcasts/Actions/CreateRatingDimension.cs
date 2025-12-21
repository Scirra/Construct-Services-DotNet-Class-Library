using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class RatingDimensions
{
    private const string CreateRatingDimensionAPIPath = "/channelcreateratingdimension.json";

    extension(BroadcastService service)
    {        
        /// <summary>
        /// Create a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(
            string strChannelID,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new DimensionResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return Ratings.Actions.Rating.CreateDimension(service, CreateRatingDimensionAPIPath, Thing.BroadcastChannel, channelIDValidator.ReturnedObject, dimensionID, title, description, maxRating, languageISO);
        }

        /// <summary>
        /// Create a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(
            Guid channelID,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
        {
            return Ratings.Actions.Rating.CreateDimension(service, CreateRatingDimensionAPIPath, Thing.BroadcastChannel, channelID, dimensionID, title, description, maxRating, languageISO);
        }

        /// <summary>
        /// Create a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> CreateRatingDimensionAsync(
            Guid channelID,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
        {
            return await Ratings.Actions.Rating.CreateDimensionAsync(service, CreateRatingDimensionAPIPath, Thing.BroadcastChannel, channelID, dimensionID, title, description, maxRating, languageISO);
        }

        /// <summary>
        /// Create a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> CreateRatingDimensionAsync(
            string strChannelID,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new DimensionResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return await Ratings.Actions.Rating.CreateDimensionAsync(service, CreateRatingDimensionAPIPath, Thing.BroadcastChannel, channelIDValidator.ReturnedObject, dimensionID, title, description, maxRating, languageISO);
        }

        /// <summary>
        /// Create a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(
            Channel channel,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
            =>
                service.CreateRatingDimension(channel.ID, dimensionID, title, description, maxRating, languageISO);

        /// <summary>
        /// Create a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> CreateRatingDimensionAsync(
            Channel channel,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
            =>
                await service.CreateRatingDimensionAsync(channel.ID, dimensionID, title, description, maxRating, languageISO);
        }
}