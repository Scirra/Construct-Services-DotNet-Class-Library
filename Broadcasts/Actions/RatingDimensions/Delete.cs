using ConstructServices.Common;
using ConstructServices.Ratings.Objects;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Broadcasts.Actions;

public static partial class RatingDimensions
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Delete an existing Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/delete-dimension" />
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(
            DeleteBroadcastChannelRatingDimensionOptions deleteBroadcastChannelRatingDimensionOptions)
            => Ratings.Actions.Rating.DeleteDimension(
                service, 
                Config.DeleteDimensionAPIPath, 
                deleteBroadcastChannelRatingDimensionOptions);

        /// <summary>
        /// Delete an existing Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/delete-dimension" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteRatingDimensionAsync(
            DeleteBroadcastChannelRatingDimensionOptions deleteBroadcastChannelRatingDimensionOptions)
            => await Ratings.Actions.Rating.DeleteDimensionAsync(
                service, 
                Config.DeleteDimensionAPIPath,
                deleteBroadcastChannelRatingDimensionOptions);

    }
}