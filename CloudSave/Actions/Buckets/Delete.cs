using System;
using System.Collections.Generic;
using ConstructServices.Common;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

[UsedImplicitly]
public static partial class Buckets
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Delete an existing CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/delete-bucket" />
        [UsedImplicitly]
        public BaseResponse DeleteBucket(Guid bucketID)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Buckets.Delete,
                service,
                DeleteBucketOptions.BuildFormData(bucketID)
            );
        }

        /// <summary>
        /// Delete an existing CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/delete-bucket" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteBucketAsync(Guid bucketID)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Buckets.Delete,
                service,
                DeleteBucketOptions.BuildFormData(bucketID)
            );
        }
    }
    
    private static class DeleteBucketOptions
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