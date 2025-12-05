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
        /// Create a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(Guid bucketID,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
        {
            const string path = "/bucketcreateratingdimension.json";
            return Ratings.Actions.Rating.CreateDimension(service, path, Thing.BroadcastChannel, bucketID, dimensionID, title, description, maxRating, languageISO);
        }

        /// <summary>
        /// Create a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse CreateRatingDimension(GameBucket bucket,
            string dimensionID,
            string title,
            string description,
            byte maxRating,
            string languageISO = null)
            => CreateRatingDimension(service, bucket.ID, dimensionID, title, description, maxRating, languageISO);
    }
}