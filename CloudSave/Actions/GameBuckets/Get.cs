using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    private const string GetBucketAPIEndPoint = "/getbucket";
    
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Get a bucket by its ID.  Doesn't return cloud saves in bucket, just the bucket itself.
        /// </summary>
        [UsedImplicitly]
        public BucketResponse GetBucket(string strBucketID)
        {
            var bucketIDValidator = Common.Validations.Guid.IsValidGuid(strBucketID);
            if (!bucketIDValidator.Successfull)
            {
                return new BucketResponse(string.Format(bucketIDValidator.ErrorMessage, "Bucket ID"), false);
            }
            return service.GetBucket(bucketIDValidator.ReturnedObject);
        }

        /// <summary>
        /// Get a bucket by its ID.  Doesn't return cloud saves in bucket, just the bucket itself.
        /// </summary>
        [UsedImplicitly]
        public async Task<BucketResponse> GetBucketAsync(string strBucketID)
        {
            var bucketIDValidator = Common.Validations.Guid.IsValidGuid(strBucketID);
            if (!bucketIDValidator.Successfull)
            {
                return new BucketResponse(string.Format(bucketIDValidator.ErrorMessage, "Bucket ID"), false);
            }
            return await service.GetBucketAsync(bucketIDValidator.ReturnedObject);
        }

        /// <summary>
        /// Get a bucket by its ID.  Doesn't return cloud saves in bucket, just the bucket itself.
        /// </summary>
        [UsedImplicitly]
        public BucketResponse GetBucket(Guid bucketID)
        {
            var formData = new Dictionary<string, string>
            {
                { "bucketID", bucketID.ToString() }
            };
            return Request.ExecuteSyncRequest<BucketResponse>(
                GetBucketAPIEndPoint,
                service,
                formData
            );
        }

        /// <summary>
        /// Get a bucket by its ID.  Doesn't return cloud saves in bucket, just the bucket itself.
        /// </summary>
        [UsedImplicitly]
        public async Task<BucketResponse> GetBucketAsync(Guid bucketID)
        {
            var formData = new Dictionary<string, string>
            {
                { "bucketID", bucketID.ToString() }
            };
            return await Request.ExecuteAsyncRequest<BucketResponse>(
                GetBucketAPIEndPoint,
                service,
                formData
            );
        }
    }
}