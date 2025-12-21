using ConstructServices.CloudSave.Enums;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    private const string CreateBucketAPIEndPoint = "/createbucket.json";
    
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Create a new bucket
        /// </summary>
        [UsedImplicitly]
        public BucketResponse CreateBucket(CloudSaveGameBucketAccessMode accessMode,
            string bucketName,
            bool allowRatings = true,
            uint? maxBlobs = null,
            uint? maxBlobSizeBytes = null,
            uint? maxBlobsPerPlayer = null)
        {
            var nameValidator = Common.Validations.BucketName.ValidateName(bucketName);
            if (!nameValidator.Successfull)
            {
                return new BucketResponse(nameValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "bucketName", bucketName },
                { "accessMode", accessMode.ToString() },
                { "allowRatings", allowRatings.ToInt().ToString() }
            };
            if (maxBlobs.HasValue)
            {
                formData.Add("maxBlobs", maxBlobs.Value.ToString());
            }
            if (maxBlobSizeBytes.HasValue)
            {
                formData.Add("maxBlobSize", maxBlobSizeBytes.Value.ToString());
            }
            if (maxBlobsPerPlayer.HasValue)
            {
                formData.Add("maxBlobsPerPlayer", maxBlobsPerPlayer.Value.ToString());
            }

            return Request.ExecuteSyncRequest<BucketResponse>(
                CreateBucketAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Create a new bucket
        /// </summary>
        [UsedImplicitly]
        public async Task<BucketResponse> CreateBucketAsync(CloudSaveGameBucketAccessMode accessMode,
            string bucketName,
            bool allowRatings = true,
            uint? maxBlobs = null,
            uint? maxBlobSizeBytes = null,
            uint? maxBlobsPerPlayer = null)
        {
            var nameValidator = Common.Validations.BucketName.ValidateName(bucketName);
            if (!nameValidator.Successfull)
            {
                return new BucketResponse(nameValidator.ErrorMessage);
            }

            var formData = new Dictionary<string, string>
            {
                { "bucketName", bucketName },
                { "accessMode", accessMode.ToString() },
                { "allowRatings", allowRatings.ToInt().ToString() }
            };
            if (maxBlobs.HasValue)
            {
                formData.Add("maxBlobs", maxBlobs.Value.ToString());
            }
            if (maxBlobSizeBytes.HasValue)
            {
                formData.Add("maxBlobSize", maxBlobSizeBytes.Value.ToString());
            }
            if (maxBlobsPerPlayer.HasValue)
            {
                formData.Add("maxBlobsPerPlayer", maxBlobsPerPlayer.Value.ToString());
            }

            return await Request.ExecuteAsyncRequest<BucketResponse>(
                CreateBucketAPIEndPoint,
                service,
                formData
            );
        }
    }
}