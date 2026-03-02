using ConstructServices.Common;
using System.Threading.Tasks;
using ConstructServices.CloudSave.Objects;
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
        public BaseResponse DeleteBucket(DeleteBucketOptions deleteBucketOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Buckets.Delete,
                service,
                deleteBucketOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Delete an existing CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/delete-bucket" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteBucketAsync(DeleteBucketOptions deleteBucketOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Buckets.Delete,
                service,
                deleteBucketOptions.BuildFormData()
            );
        }
    }
}