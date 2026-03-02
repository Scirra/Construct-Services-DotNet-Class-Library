using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.CloudSave.Objects;

namespace ConstructServices.CloudSave.Actions;

public static partial class Buckets
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Update an existing CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/edit-bucket" />
        [UsedImplicitly]
        public BaseResponse UpdateBucket(UpdateBucketOptions updateBucketOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Buckets.Update,
                service,
                updateBucketOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Update an existing CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/edit-bucket" />
        [UsedImplicitly]
        public async Task<BaseResponse> UpdateBucketAsync(UpdateBucketOptions updateBucketOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Buckets.Update,
                service,
                updateBucketOptions.BuildFormData()
            );
        }
    }
}