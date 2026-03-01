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
        /// Update an existing Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/edit-dimension" />
        [UsedImplicitly]
        public DimensionResponse UpdateRatingDimension(
            UpdateBroadcastChannelRatingDimensionOptions updateBroadcastChannelRatingDimensionOptions)
        {
            return global::ConstructServices.Ratings.Actions.Dimensions.UpdateDimension(service, Config.EditDimensionAPIPath, updateBroadcastChannelRatingDimensionOptions);
        }        
        
        /// <summary>
        /// Update an existing Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/edit-dimension" />
        public async Task<DimensionResponse> UpdateRatingDimensionAsync(
            UpdateBroadcastChannelRatingDimensionOptions updateBroadcastChannelRatingDimensionOptions)
        {
            return await global::ConstructServices.Ratings.Actions.Dimensions.UpdateDimensionAsync(service, Config.EditDimensionAPIPath, updateBroadcastChannelRatingDimensionOptions);
        }
    }
}