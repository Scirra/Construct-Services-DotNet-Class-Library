using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class RatingDimensions
{
    private const string GetDimensionsAPIPath = "/channelgetratingdimensions.json";

    extension(BroadcastService service)
    {
        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(Guid channelID)
        {
            return Ratings.Actions.Rating.GetDimensions(service, GetDimensionsAPIPath, Thing.BroadcastChannel, channelID);
        }

        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionsResponse> GetRatingDimensionsAsync(Guid channelID)
        {
            return await Ratings.Actions.Rating.GetDimensionsAsync(service, GetDimensionsAPIPath, Thing.BroadcastChannel, channelID);
        }

        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(string strChannelID)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new DimensionsResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return Ratings.Actions.Rating.GetDimensions(service, GetDimensionsAPIPath, Thing.BroadcastChannel, channelIDValidator.ReturnedObject);
        }

        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionsResponse> GetRatingDimensionsAsync(string strChannelID)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new DimensionsResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return await Ratings.Actions.Rating.GetDimensionsAsync(service, GetDimensionsAPIPath, Thing.BroadcastChannel, channelIDValidator.ReturnedObject);
        }

        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(Channel channel)
            => service.GetRatingDimensions(channel.ID);

        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionsResponse> GetRatingDimensionsAsync(Channel channel)
            => await service.GetRatingDimensionsAsync(channel.ID);
    }
}