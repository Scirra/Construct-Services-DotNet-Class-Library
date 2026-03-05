using System.Collections.Generic;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.CloudSave.Enums;

namespace ConstructServices.CloudSave.Actions;

public static partial class Buckets
{
    extension(CloudSaveServiceBase service)
    {
        /// <summary>
        /// List all CloudSave Buckets
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/get-buckets" />
        [UsedImplicitly]
        public BucketsResponse ListBuckets(
            ListBucketOptions listBucketOptions,
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<BucketsResponse>(
                Config.EndPointPaths.Buckets.List,
                service,
                listBucketOptions.BuildFormData(),
                paginationOptions
            );
        }

        /// <summary>
        /// List all CloudSave Buckets
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/get-buckets" />
        [UsedImplicitly]
        public async Task<BucketsResponse> ListBucketsAsync(
            ListBucketOptions listBucketOptions,
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<BucketsResponse>(
                Config.EndPointPaths.Buckets.List,
                service,
                listBucketOptions.BuildFormData(),
                paginationOptions
            );
        }
    }

    [UsedImplicitly]
    public sealed class ListBucketOptions
    {
        [UsedImplicitly]
        public GetBucketsSortMethod? SortBy { private get; set; }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (SortBy.HasValue)
            {
                formData.Add("orderBy", SortBy.ToString());
            }
            return formData;
        }
    }

}