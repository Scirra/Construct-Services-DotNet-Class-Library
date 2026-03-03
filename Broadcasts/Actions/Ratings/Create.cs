using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Ratings.Actions;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Ratings
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Creates a new Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/create-dimension" />
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(
            Dimensions.CreateBroadcastChannelRatingDimensionOptions createBroadcastChannelRatingDimensionOptions)
        {
            return service.CreateDimension(Config.EndPointPaths.Ratings.CreateDimension,
                createBroadcastChannelRatingDimensionOptions
            );
        }

        /// <summary>
        /// Creates a new Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/create-dimension" />
        [UsedImplicitly]
        public async Task<DimensionResponse> CreateRatingDimensionAsync(
            Dimensions.CreateBroadcastChannelRatingDimensionOptions createBroadcastChannelRatingDimensionOptions)
        {
            return await service.CreateDimensionAsync(Config.EndPointPaths.Ratings.CreateDimension,
                createBroadcastChannelRatingDimensionOptions);
        }
    }
}