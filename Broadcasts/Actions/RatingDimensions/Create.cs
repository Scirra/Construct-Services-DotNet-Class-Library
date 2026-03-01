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
        /// Creates a new Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/create-dimension" />
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(
            CreateBroadcastChannelRatingDimensionOptions createBroadcastChannelRatingDimensionOptions)
        {
            return Ratings.Actions.Rating.CreateDimension(
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
            return await Ratings.Actions.Rating.CreateDimensionAsync(
                service, 
                Config.CreateRatingDimensionAPIPath,
                createBroadcastChannelRatingDimensionOptions);
        }
    }
}