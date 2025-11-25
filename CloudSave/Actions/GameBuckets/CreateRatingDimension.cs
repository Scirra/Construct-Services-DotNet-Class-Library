using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Create a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(Guid bucketID,
            string dimensionID,
            string title,
            string description,
            byte maxRating)
        {
            const string path = "/bucketcreateratingdimension.json";
            return Ratings.Actions.Rating.CreateDimension(service, path, Thing.CloudSaveBucket, bucketID, dimensionID, title, description, maxRating);
        }

        /// <summary>
        /// Create a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(GameBucket bucket,
            string dimensionID,
            string title,
            string description,
            byte maxRating)
            => CreateRatingDimension(service, bucket.ID, dimensionID, title, description, maxRating);
    }
}