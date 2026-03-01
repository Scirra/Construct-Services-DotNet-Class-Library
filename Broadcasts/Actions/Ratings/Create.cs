using ConstructServices.Ratings.Objects;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

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
            CreateBroadcastChannelRatingDimensionOptions createBroadcastChannelRatingDimensionOptions)
        {
            return global::ConstructServices.Ratings.Actions.Dimensions.CreateDimension(
                service,
                Config.CreateRatingDimensionAPIPath,
                createBroadcastChannelRatingDimensionOptions
            );
        }

        /// <summary>
        /// Creates a new Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/create-dimension" />
        public async Task<DimensionResponse> CreateRatingDimensionAsync(
            CreateBroadcastChannelRatingDimensionOptions createBroadcastChannelRatingDimensionOptions)
        {
            return await global::ConstructServices.Ratings.Actions.Dimensions.CreateDimensionAsync(
                service, 
                Config.CreateRatingDimensionAPIPath,
                createBroadcastChannelRatingDimensionOptions);
        }
    }
}