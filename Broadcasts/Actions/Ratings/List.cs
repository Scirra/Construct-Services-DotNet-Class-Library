using System;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Common;
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
        public DimensionsResponse ListRatingDimensions(Guid channelID)
            => service.ListDimensions(
                Thing.BroadcastChannel,
                channelID,
                Config.EndPointPaths.Ratings.ListDimensions
            );

        /// <summary>
        /// List all Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/get-dimensions" />
        [UsedImplicitly]
        public async Task<DimensionsResponse> ListRatingDimensionsAsync(Guid channelID)
            => await service.ListDimensionsAsync(
                Thing.BroadcastChannel,
                channelID,
                Config.EndPointPaths.Ratings.ListDimensions
            );
    }
}