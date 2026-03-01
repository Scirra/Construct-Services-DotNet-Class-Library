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
        /// Update an existing Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/edit-dimension" />
        [UsedImplicitly]
        public DimensionResponse UpdateRatingDimension(
            UpdateBroadcastChannelRatingDimensionOptions updateBroadcastChannelRatingDimensionOptions)
        {
            return Ratings.Actions.Rating.UpdateDimension(service, Config.EditDimensionAPIPath, updateBroadcastChannelRatingDimensionOptions);
        }        
        
        /// <summary>
        /// Update an existing Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/edit-dimension" />
        public async Task<DimensionResponse> UpdateRatingDimensionAsync(
            UpdateBroadcastChannelRatingDimensionOptions updateBroadcastChannelRatingDimensionOptions)
        {
            return await Ratings.Actions.Rating.UpdateDimensionAsync(service, Config.EditDimensionAPIPath, updateBroadcastChannelRatingDimensionOptions);
        }
    }
}