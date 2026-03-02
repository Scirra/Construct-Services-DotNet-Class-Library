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
        /// List all Saves in a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/get-cloud-saves" />
        [UsedImplicitly]
        public CloudSavesResponse ListCloudSaves(
            ListBucketSavesOptions listBucketSavesOptions,
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<CloudSavesResponse>(
                Config.EndPointPaths.Saves.ListBucketSaves,
                service,
                listBucketSavesOptions.BuildFormData(),
                paginationOptions
            );
        }

        /// <summary>
        /// List all Saves in a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/get-cloud-saves" />
        [UsedImplicitly]
        public async Task<CloudSavesResponse> ListCloudSavesAsync(
            ListBucketSavesOptions listBucketSavesOptions,
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<CloudSavesResponse>(
                Config.EndPointPaths.Saves.ListBucketSaves,
                service,
                listBucketSavesOptions.BuildFormData(),
                paginationOptions
            );
        }
    }
}