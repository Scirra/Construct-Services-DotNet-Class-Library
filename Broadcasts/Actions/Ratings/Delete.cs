using System;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Ratings.Actions;

namespace ConstructServices.Broadcasts.Actions;

public static partial class Ratings
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Delete an existing Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/delete-dimension" />
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(Guid channelID, string dimensionID)
            => service.DeleteDimension(
                Thing.BroadcastChannel,
                channelID,
                dimensionID,
                Config.EndPointPaths.Ratings.DeleteDimension);

        /// <summary>
        /// Delete an existing Rating Dimension on a Broadcast Channel
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/broadcasts/api-end-points/ratings/delete-dimension" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteRatingDimensionAsync(Guid channelID, string dimensionID)
            => await service.DeleteDimensionAsync(
                Thing.BroadcastChannel,
                channelID,
                dimensionID,
                Config.EndPointPaths.Ratings.DeleteDimension);

    }
}