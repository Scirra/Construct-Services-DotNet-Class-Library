using ConstructServices.Ratings.Actions;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using ConstructServices.Common;
using static ConstructServices.Ratings.Actions.Dimensions;

namespace ConstructServices.Broadcasts.Actions;
public static partial class Ratings
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Update an existing Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/edit-dimension" />
        [UsedImplicitly]
        public DimensionResponse UpdateRatingDimension(
            Guid channelID,
            string dimensionID,
            UpdateRatingDimensionOptions updateRatingDimensionOptions)
        {
            return service.UpdateDimension(
                Thing.BroadcastChannel,
                channelID,
                dimensionID,
                Config.EndPointPaths.Ratings.UpdateDimension,
                updateRatingDimensionOptions
            );
        }        
        
        /// <summary>
        /// Update an existing Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/edit-dimension" />
        [UsedImplicitly]
        public async Task<DimensionResponse> UpdateRatingDimensionAsync(
            Guid channelID,
            string dimensionID,
            UpdateRatingDimensionOptions updateRatingDimensionOptions)
        {
            return await service.UpdateDimensionAsync(
                Thing.BroadcastChannel,
                channelID,
                dimensionID,
                Config.EndPointPaths.Ratings.UpdateDimension,
                updateRatingDimensionOptions
            );
        }
    }
}