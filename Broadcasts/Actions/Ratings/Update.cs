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
        /// Update an existing Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/edit-dimension" />
        [UsedImplicitly]
        public DimensionResponse UpdateRatingDimension(
            Dimensions.UpdateBroadcastChannelRatingDimensionOptions updateBroadcastChannelRatingDimensionOptions)
        {
            return service.UpdateDimension(Config.EndPointPaths.Ratings.UpdateDimension, updateBroadcastChannelRatingDimensionOptions);
        }        
        
        /// <summary>
        /// Update an existing Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/edit-dimension" />
        public async Task<DimensionResponse> UpdateRatingDimensionAsync(
            Dimensions.UpdateBroadcastChannelRatingDimensionOptions updateBroadcastChannelRatingDimensionOptions)
        {
            return await service.UpdateDimensionAsync(Config.EndPointPaths.Ratings.UpdateDimension, updateBroadcastChannelRatingDimensionOptions);
        }
    }
}