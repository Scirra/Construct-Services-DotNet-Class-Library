using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;

namespace ConstructServices.CloudSave.Actions;

public static partial class RatingDimensions
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Edit a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(Guid bucketID)
        {
            const string path = "/bucketgetratingdimensions.json";
            return Ratings.Actions.Rating.GetDimensions(service, path, Thing.BroadcastChannel, bucketID);
        }

        /// <summary>
        /// Edit a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionsResponse GetRatingDimensions(GameBucket bucket)
            =>
                service.GetRatingDimensions(bucket.ID);
    }
}