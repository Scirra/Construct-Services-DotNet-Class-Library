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
        public DimensionsResponse GetRatingDimensions(Guid channelID)
        {
            return Ratings.Actions.Rating.GetDimensions(service, Config.GetDimensionsAPIPath, Thing.BroadcastChannel, channelID);
        }

        [UsedImplicitly]
        public async Task<DimensionsResponse> GetRatingDimensionsAsync(Guid channelID)
        {
            return await Ratings.Actions.Rating.GetDimensionsAsync(service, Config.GetDimensionsAPIPath, Thing.BroadcastChannel, channelID);
        }

        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(string strChannelID)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new DimensionsResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return Ratings.Actions.Rating.GetDimensions(service, Config.GetDimensionsAPIPath, Thing.BroadcastChannel, channelIDValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<DimensionsResponse> GetRatingDimensionsAsync(string strChannelID)
        {
            var channelIDValidator = Common.Validations.Guid.IsValidGuid(strChannelID);
            if (!channelIDValidator.Successfull)
            {
                return new DimensionsResponse(string.Format(channelIDValidator.ErrorMessage, "Channel ID"));
            }
            return await Ratings.Actions.Rating.GetDimensionsAsync(service, Config.GetDimensionsAPIPath, Thing.BroadcastChannel, channelIDValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(Channel channel)
            => service.GetRatingDimensions(channel.ID);

        [UsedImplicitly]
        public async Task<DimensionsResponse> GetRatingDimensionsAsync(Channel channel)
            => await service.GetRatingDimensionsAsync(channel.ID);
    }
}