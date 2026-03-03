using System;
using System.Collections.Generic;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class Buckets
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Get an existing CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/get-bucket" />
        [UsedImplicitly]
        public BucketResponse GetBucket(Guid bucketID)
        {
            return Request.ExecuteSyncRequest<BucketResponse>(
                Config.EndPointPaths.Buckets.Get,
                service,
                GetBucketOptions.BuildFormData(bucketID)
            );
        }

        /// <summary>
        /// Get an existing CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/get-bucket" />
        [UsedImplicitly]
        public async Task<BucketResponse> GetBucketAsync(Guid bucketID)
        {
            return await Request.ExecuteAsyncRequest<BucketResponse>(
                Config.EndPointPaths.Buckets.Get,
                service,
                GetBucketOptions.BuildFormData(bucketID)
            );
        }
    }
    
    private static class GetBucketOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid bucketID)
        {
            var formData = new Dictionary<string, string>
            {
                { "bucketID", bucketID.ToString() }
            };
            return formData;
        }
    }
}