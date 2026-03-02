using ConstructServices.CloudSave.Objects;
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
        public BucketResponse GetBucket(GetBucketOptions getBucketOptions)
        {
            return Request.ExecuteSyncRequest<BucketResponse>(
                Config.EndPointPaths.Buckets.Get,
                service,
                getBucketOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Get an existing CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/get-bucket" />
        [UsedImplicitly]
        public async Task<BucketResponse> GetBucketAsync(GetBucketOptions getBucketOptions)
        {
            return await Request.ExecuteAsyncRequest<BucketResponse>(
                Config.EndPointPaths.Buckets.Get,
                service,
                getBucketOptions.BuildFormData()
            );
        }
    }
}