using System;
using ConstructServices.Broadcasts.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;

namespace ConstructServices.Broadcasts.Actions;

public static partial class RatingDimensions
{
    extension(BroadcastService service)
    {
        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse EditRatingDimension(Guid bucketID,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null)
        {
            const string path = "/channeleditratingdimension.json";
            return Ratings.Actions.Rating.EditDimension(service, path, Thing.CloudSaveBlob, bucketID, dimensionID, newTitle, newDescription, newMaxRating);
        }

        /// <summary>
        /// Edit a rating dimension for a channel
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse EditRatingDimension(Channel channel,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null)
            => EditRatingDimension(service, channel.ID, dimensionID, newTitle, newDescription, newMaxRating);
    }
}