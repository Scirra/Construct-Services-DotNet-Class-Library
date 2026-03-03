using ConstructServices.Ratings.Actions;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
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
                Config.EndPointPaths.Ratings.UpdateDimension,
                channelID,
                dimensionID,
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
                Config.EndPointPaths.Ratings.UpdateDimension, 
                channelID,
                dimensionID,
                updateRatingDimensionOptions
            );
        }
    }
}