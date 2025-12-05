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
        /// Edit a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse EditRatingDimension(Guid bucketID,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
        {
            const string path = "/bucketeditratingdimension.json";
            return Ratings.Actions.Rating.EditDimension(service, path, Thing.CloudSaveBlob, bucketID, dimensionID, newTitle, newDescription, newMaxRating, newLanguageISO);
        }

        /// <summary>
        /// Edit a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse EditRatingDimension(GameBucket bucket,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
            => EditRatingDimension(service, bucket.ID, dimensionID, newTitle, newDescription, newMaxRating, newLanguageISO);
    }
}