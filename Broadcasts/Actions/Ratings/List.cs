using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Ratings.Actions;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Ratings
{
    extension(BroadcastServiceBase service)
    {        
        /// <summary>
        /// List all Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/get-dimensions" />
        [UsedImplicitly]
        public DimensionsResponse ListRatingDimensions(
            Dimensions.ListBroadcastChannelDimensionOptions listBroadcastChannelDimensionOptions)
            => service.ListDimensions(Config.EndPointPaths.Ratings.ListDimensions, listBroadcastChannelDimensionOptions);

        /// <summary>
        /// List all Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/get-dimensions" />
        [UsedImplicitly]
        public async Task<DimensionsResponse> ListRatingDimensionsAsync(
            Dimensions.ListBroadcastChannelDimensionOptions listBroadcastChannelDimensionOptions)
            => await service.ListDimensionsAsync(Config.EndPointPaths.Ratings.ListDimensions, listBroadcastChannelDimensionOptions);
    }
}