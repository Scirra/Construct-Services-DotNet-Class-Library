using ConstructServices.CloudSave.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Responses;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    private const string EditDimensionAPIEndPoint = "/bucketeditratingdimension.json";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Edit a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse EditRatingDimension(
            string strBucketID,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
        {
            var bucketIDValidator = Common.Validations.Guid.IsValidGuid(strBucketID);
            if (!bucketIDValidator.Successfull)
            {
                return new DimensionResponse(string.Format(bucketIDValidator.ErrorMessage, "Bucket ID"));
            }
            return Ratings.Actions.Rating.EditDimension(service, EditDimensionAPIEndPoint, Thing.CloudSaveBlob, bucketIDValidator.ReturnedObject, dimensionID, newTitle, newDescription, newMaxRating, newLanguageISO);
        }

        /// <summary>
        /// Edit a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> EditRatingDimensionAsync(
            string strBucketID,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
        {
            var bucketIDValidator = Common.Validations.Guid.IsValidGuid(strBucketID);
            if (!bucketIDValidator.Successfull)
            {
                return new DimensionResponse(string.Format(bucketIDValidator.ErrorMessage, "Bucket ID"));
            }
            return await Ratings.Actions.Rating.EditDimensionAsync(service, EditDimensionAPIEndPoint, Thing.CloudSaveBlob, bucketIDValidator.ReturnedObject, dimensionID, newTitle, newDescription, newMaxRating, newLanguageISO);
        }

        /// <summary>
        /// Edit a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse EditRatingDimension(
            Guid bucketID,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
        {
            return Ratings.Actions.Rating.EditDimension(service, EditDimensionAPIEndPoint, Thing.CloudSaveBlob, bucketID, dimensionID, newTitle, newDescription, newMaxRating, newLanguageISO);
        }

        /// <summary>
        /// Edit a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> EditRatingDimensionAsync(
            Guid bucketID,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
        {
            return await Ratings.Actions.Rating.EditDimensionAsync(service, EditDimensionAPIEndPoint, Thing.CloudSaveBlob, bucketID, dimensionID, newTitle, newDescription, newMaxRating, newLanguageISO);
        }

        /// <summary>
        /// Edit a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public DimensionResponse EditRatingDimension(
            GameBucket bucket,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
            =>
                service.EditRatingDimension(bucket.ID, dimensionID, newTitle, newDescription, newMaxRating, newLanguageISO);

        /// <summary>
        /// Edit a rating dimension for a bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<DimensionResponse> EditRatingDimensionAsync(
            GameBucket bucket,
            string dimensionID,
            string newTitle = null,
            string newDescription = null,
            byte? newMaxRating = null,
            string newLanguageISO = null)
            =>
                await service.EditRatingDimensionAsync(bucket.ID, dimensionID, newTitle, newDescription, newMaxRating, newLanguageISO);

    }
}