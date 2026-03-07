using System;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Common;
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
            Guid channelID,
            Dimensions.CreateRatingDimensionOptions createRatingDimensionOptions)
        {
            return service.CreateDimension(
                Thing.BroadcastChannel,
                channelID,
                Config.EndPointPaths.Ratings.CreateDimension,
                createRatingDimensionOptions
            );
        }

        /// <summary>
        /// Creates a new Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/create-dimension" />
        [UsedImplicitly]
        public async Task<DimensionResponse> CreateRatingDimensionAsync(
            Guid channelID,
            Dimensions.CreateRatingDimensionOptions createRatingDimensionOptions)
        {
            return await service.CreateDimensionAsync(
                Thing.BroadcastChannel,
                channelID,
                Config.EndPointPaths.Ratings.CreateDimension,
                createRatingDimensionOptions);
        }
    }
}