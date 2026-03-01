using ConstructServices.Ratings.Objects;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class RatingDimensions
{
    extension(BroadcastService service)
    {        
        /// <summary>
        /// List all Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/get-dimensions" />
        [UsedImplicitly]
        public DimensionsResponse ListRatingDimensions(
            ListBroadcastChannelDimensionOptions listBroadcastChannelDimensionOptions)
            => Ratings.Actions.Rating.GetDimensions(service, Config.GetDimensionsAPIPath, listBroadcastChannelDimensionOptions);

        /// <summary>
        /// List all Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/get-dimensions" />
        [UsedImplicitly]
        public async Task<DimensionsResponse> ListRatingDimensionsAsync(
            ListBroadcastChannelDimensionOptions listBroadcastChannelDimensionOptions)
            => await Ratings.Actions.Rating.GetDimensionsAsync(service, Config.GetDimensionsAPIPath, listBroadcastChannelDimensionOptions);
    }
}