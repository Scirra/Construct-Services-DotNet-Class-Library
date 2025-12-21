using ConstructServices.CloudSave.Enums;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.CloudSave.Objects;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    private const string EditBucketAPIEndPoint = "/editbucket.json";

    extension(CloudSaveService service)
    {
        /// <summary>
        /// Edit a buckets properties.
        /// </summary>
        [UsedImplicitly]
        public BaseResponse EditBucket(
            string strBucketID,
            CloudSaveGameBucketAccessMode? newAccessMode,
            string newBucketName = null,
            bool? newAllowRatings = null,
            uint? newMaxBlobs = null,
            uint? newMaxBlobSizeBytes = null,
            uint? newMaxBlobsPerPlayer = null)
        {
            var bucketIDValidator = Common.Validations.Guid.IsValidGuid(strBucketID);
            if (!bucketIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(bucketIDValidator.ErrorMessage, "Bucket ID"), false);
            }
            return service.EditBucket(bucketIDValidator.ReturnedObject, newAccessMode, newBucketName, newAllowRatings,
                newMaxBlobs, newMaxBlobSizeBytes, newMaxBlobsPerPlayer);
        }

        /// <summary>
        /// Edit a buckets properties.
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> EditBucketAsync(
            string strBucketID,
            CloudSaveGameBucketAccessMode? newAccessMode,
            string newBucketName = null,
            bool? newAllowRatings = null,
            uint? newMaxBlobs = null,
            uint? newMaxBlobSizeBytes = null,
            uint? newMaxBlobsPerPlayer = null)
        {
            var bucketIDValidator = Common.Validations.Guid.IsValidGuid(strBucketID);
            if (!bucketIDValidator.Successfull)
            {
                return new BaseResponse(string.Format(bucketIDValidator.ErrorMessage, "Bucket ID"), false);
            }
            return await service.EditBucketAsync(bucketIDValidator.ReturnedObject, newAccessMode, newBucketName, newAllowRatings,
                newMaxBlobs, newMaxBlobSizeBytes, newMaxBlobsPerPlayer);
        }

        /// <summary>
        /// Edit a buckets properties.
        /// </summary>
        [UsedImplicitly]
        public BaseResponse EditBucket(
            GameBucket bucket,
            CloudSaveGameBucketAccessMode? newAccessMode,
            string newBucketName = null,
            bool? newAllowRatings = null,
            uint? newMaxBlobs = null,
            uint? newMaxBlobSizeBytes = null,
            uint? newMaxBlobsPerPlayer = null)
            =>
                service.EditBucket(bucket.ID, newAccessMode, newBucketName, newAllowRatings, newMaxBlobs, newMaxBlobSizeBytes,
                    newMaxBlobsPerPlayer);


        /// <summary>
        /// Edit a buckets properties.
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> EditBucketAsync(
            GameBucket bucket,
            CloudSaveGameBucketAccessMode? newAccessMode,
            string newBucketName = null,
            bool? newAllowRatings = null,
            uint? newMaxBlobs = null,
            uint? newMaxBlobSizeBytes = null,
            uint? newMaxBlobsPerPlayer = null)
            =>
                await service.EditBucketAsync(bucket.ID, newAccessMode, newBucketName, newAllowRatings, newMaxBlobs, newMaxBlobSizeBytes,
                    newMaxBlobsPerPlayer);

        /// <summary>
        /// Edit a buckets properties.
        /// </summary>
        [UsedImplicitly]
        public BaseResponse EditBucket(
            Guid bucketID,
            CloudSaveGameBucketAccessMode? newAccessMode,
            string newBucketName = null,
            bool? newAllowRatings = null,
            uint? newMaxBlobs = null,
            uint? newMaxBlobSizeBytes = null,
            uint? newMaxBlobsPerPlayer = null)
        {
            var formData = new Dictionary<string, string>
            {
                { "bucketID", bucketID.ToString() }
            };

            if (newAccessMode.HasValue)
            {
                formData.Add("accessMode", newAccessMode.Value.ToString());
            }
            if (!string.IsNullOrEmpty(newBucketName))
            {
                formData.Add("bucketName", newBucketName);
            }
            if (newAllowRatings.HasValue)
            {
                formData.Add("allowRatings", newAllowRatings.Value.ToInt().ToString() );
            }
            if (newMaxBlobs.HasValue)
            {
                formData.Add("maxBlobs", newMaxBlobs.Value.ToString());
            }
            if (newMaxBlobSizeBytes.HasValue)
            {
                formData.Add("maxBlobSize", newMaxBlobSizeBytes.Value.ToString());
            }
            formData.Add("maxBlobsPerPlayer", newMaxBlobsPerPlayer?.ToString() ?? string.Empty);

            return Request.ExecuteSyncRequest<BaseResponse>(
                EditBucketAPIEndPoint,
                service,
                formData
            );
        }
        /// <summary>
        /// Edit a buckets properties.
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> EditBucketAsync(
            Guid bucketID,
            CloudSaveGameBucketAccessMode? newAccessMode,
            string newBucketName = null,
            bool? newAllowRatings = null,
            uint? newMaxBlobs = null,
            uint? newMaxBlobSizeBytes = null,
            uint? newMaxBlobsPerPlayer = null)
        {
            var formData = new Dictionary<string, string>
            {
                { "bucketID", bucketID.ToString() }
            };

            if (newAccessMode.HasValue)
            {
                formData.Add("accessMode", newAccessMode.Value.ToString());
            }
            if (!string.IsNullOrEmpty(newBucketName))
            {
                formData.Add("bucketName", newBucketName);
            }
            if (newAllowRatings.HasValue)
            {
                formData.Add("allowRatings", newAllowRatings.Value.ToInt().ToString() );
            }
            if (newMaxBlobs.HasValue)
            {
                formData.Add("maxBlobs", newMaxBlobs.Value.ToString());
            }
            if (newMaxBlobSizeBytes.HasValue)
            {
                formData.Add("maxBlobSize", newMaxBlobSizeBytes.Value.ToString());
            }
            formData.Add("maxBlobsPerPlayer", newMaxBlobsPerPlayer?.ToString() ?? string.Empty);

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                EditBucketAPIEndPoint,
                service,
                formData
            );
        }
    }
}