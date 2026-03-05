using ConstructServices.CloudSave.Enums;
using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class Buckets
{
    extension(CloudSaveServiceBase service)
    {        
        /// <summary>
        /// List all Saves in a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/get-cloud-saves" />
        [UsedImplicitly]
        public CloudSavesResponse ListCloudSaves(
            Guid bucketID,
            ListBucketSavesOptions listBucketSavesOptions,
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<CloudSavesResponse>(
                Config.EndPointPaths.Saves.ListBucketSaves,
                service,
                listBucketSavesOptions.BuildFormData(bucketID),
                paginationOptions
            );
        }

        /// <summary>
        /// List all Saves in a CloudSave Bucket
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/cloud-save/api-end-points/buckets/get-cloud-saves" />
        [UsedImplicitly]
        public async Task<CloudSavesResponse> ListCloudSavesAsync(
            Guid bucketID,
            ListBucketSavesOptions listBucketSavesOptions,
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<CloudSavesResponse>(
                Config.EndPointPaths.Saves.ListBucketSaves,
                service,
                listBucketSavesOptions.BuildFormData(bucketID),
                paginationOptions
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class ListBucketSavesOptions(
        ListBucketCloudSaveSortMethod sortBy,
        ListBucketCloudSaveFilters filters = null)
    {
        private ListBucketCloudSaveSortMethod? SortBy { get; } = sortBy;
        private ListBucketCloudSaveFilters Filters { get; } = filters;

        internal Dictionary<string, string> BuildFormData(Guid bucketID)
        {
            var formData = new Dictionary<string, string>
            {
                { "mode", "Bucket" },
                { "bucketID", bucketID.ToString() }
            };
            if (SortBy.HasValue)
            {
                formData.Add("orderBy", SortBy.ToString());
            }
            // Filters
            if (Filters != null)
            {
                if (!string.IsNullOrWhiteSpace(Filters.Name))
                {
                    formData.Add("name", Filters.Name);
                }

                if (!string.IsNullOrWhiteSpace(Filters.Key))
                {
                    formData.Add("key", Filters.Key);
                }

                var playerIDs = Filters.PlayerIDs;
                if (playerIDs != null && playerIDs.Any())
                {
                    formData.Add("playerIDs", string.Join(",", playerIDs));
                }

                var blobIDs = Filters.BlobIDs;
                if (blobIDs != null && blobIDs.Any())
                {
                    formData.Add("blobIDs", string.Join(",", blobIDs));
                }

                var totalRatings = Filters.TotalRatings;
                if (totalRatings != null && totalRatings.Any())
                {
                    formData.Add("totalRatings", string.Join(",", totalRatings.Select(c => (c.Key ?? string.Empty).Trim() + "=" + c.Value)));
                }

                var minRatings = Filters.MinRating;
                if (minRatings != null && minRatings.Any())
                {
                    formData.Add("rating", string.Join(",", minRatings.Select(c => (c.Key ?? string.Empty).Trim() + "=" + c.Value)));
                }
            }
            return formData;
        }
    }
}