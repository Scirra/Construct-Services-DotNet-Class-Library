using ConstructServices.CloudSave.Enums;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class Buckets
{
    extension(CloudSaveService service)
    {
        /// <summary>
        /// Get paginated buckets for a game
        /// </summary>
        [UsedImplicitly]
        public BucketsResponse GetBuckets(GetBucketsSortMethod sortBy,
            PaginationOptions paginationOptions)
        {
            var formData = new Dictionary<string, string>
            {
                { "orderBy", sortBy.ToString() }
            };

            return Request.ExecuteSyncRequest<BucketsResponse>(
                Config.GetBucketsAPIEndPoint,
                service,
                formData,
                paginationOptions
            );
        }

        /// <summary>
        /// Get paginated buckets for a game
        /// </summary>
        [UsedImplicitly]
        public async Task<BucketsResponse> GetBucketsAsync(GetBucketsSortMethod sortBy,
            PaginationOptions paginationOptions)
        {
            var formData = new Dictionary<string, string>
            {
                { "orderBy", sortBy.ToString() }
            };

            return await Request.ExecuteAsyncRequest<BucketsResponse>(
                Config.GetBucketsAPIEndPoint,
                service,
                formData,
                paginationOptions
            );
        }
    }
}