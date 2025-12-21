using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;

namespace ConstructServices.Broadcasts.Actions;

public static partial class RatingDimensions
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Delete a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(Guid bucketID,
            string dimensionID)
        {
            const string path = "/channeldeleteratingsdimension.json";
            return Ratings.Actions.Rating.DeleteDimension(service, path, Thing.BroadcastChannel, bucketID, dimensionID);
        }

        /// <summary>
        /// Delete a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteRatingDimension(Channel channel,
            string dimensionID) 
            =>
                service.DeleteRatingDimension(channel.ID, dimensionID);
    }
}