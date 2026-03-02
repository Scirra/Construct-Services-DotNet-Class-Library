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
        /// Creates a new CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/create-bucket" />
        [UsedImplicitly]
        public BucketResponse CreateBucket(CreateBucketOptions createBucketOptions)
        {
            return Request.ExecuteSyncRequest<BucketResponse>(
                Config.EndPointPaths.Buckets.Create,
                service,
                createBucketOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Creates a new CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/create-bucket" />
        [UsedImplicitly]
        public async Task<BucketResponse> CreateBucketAsync(CreateBucketOptions createBucketOptions)
        {
            return await Request.ExecuteAsyncRequest<BucketResponse>(
                Config.EndPointPaths.Buckets.Create,
                service,
                createBucketOptions.BuildFormData()
            );
        }
    }
}