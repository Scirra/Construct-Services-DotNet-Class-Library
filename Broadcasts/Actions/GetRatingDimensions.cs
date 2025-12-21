using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;

namespace ConstructServices.Broadcasts.Actions;

public static partial class RatingDimensions
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(Guid bucketID)
        {
            const string path = "/channelgetratingdimensions.json";
            return Ratings.Actions.Rating.GetDimensions(service, path, Thing.BroadcastChannel, bucketID);
        }

        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(Channel channel)
            =>
                service.GetRatingDimensions(channel.ID);
    }
}