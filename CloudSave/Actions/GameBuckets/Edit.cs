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
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Edit a buckets properties.
        /// </summary>
        [UsedImplicitly]
        public BaseResponse EditBucket(Guid bucketID,
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
            if (newMaxBlobsPerPlayer.HasValue)
            {
                formData.Add("maxBlobsPerPlayer", newMaxBlobsPerPlayer.Value.ToString());
            }

            const string path = "/editbucket.json";
            return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
                path,
                service,
                formData
            )).Result;
        }

        /// <summary>
        /// Edit a buckets properties.
        /// </summary>
        [UsedImplicitly]
        public BaseResponse EditBucket(GameBucket bucket,
            CloudSaveGameBucketAccessMode? newAccessMode,
            string newBucketName = null,
            bool? newAllowRatings = null,
            uint? newMaxBlobs = null,
            uint? newMaxBlobSizeBytes = null,
            uint? newMaxBlobsPerPlayer = null)
            => EditBucket(service, bucket.ID, newAccessMode, newBucketName, newAllowRatings, newMaxBlobs, newMaxBlobSizeBytes,
                newMaxBlobsPerPlayer);
    }
}