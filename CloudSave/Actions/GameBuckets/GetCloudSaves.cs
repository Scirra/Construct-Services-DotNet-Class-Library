﻿using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructServices.CloudSave.Objects;

namespace ConstructServices.CloudSave.Actions;

public static partial class GameBuckets
{
    public class GetBucketCloudSaveFilters
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public HashSet<Guid> PlayerIDs { get; set; }
        public Dictionary<string, int> TotalRatings { get; set; }
        public Dictionary<string, byte> MinRating { get; set; }
    }

    /// <summary>
    /// Return paginated cloud saves within a bucket
    /// </summary>
    [UsedImplicitly]
    public static CloudSavesResponse GetCloudSaves(
        this CloudSaveService service,
        Guid bucketID,
        PaginationOptions paginationOptions,
        Enums.GetBucketCloudSaveSortMethod? orderBy = null,
        GetBucketCloudSaveFilters filters = null)
    {
        var formData = new Dictionary<string, string>
        {
            { "mode", "Bucket" },
            { "bucketID", bucketID.ToString() }
        };
        if (orderBy.HasValue)
        {
            formData.Add("orderBy", orderBy.Value.ToString());
        }

        // Filters
        if (filters != null)
        {
            if (!string.IsNullOrWhiteSpace(filters.Name))
            {
                formData.Add("name", filters.Name);
            }

            if (!string.IsNullOrWhiteSpace(filters.Key))
            {
                formData.Add("key", filters.Key);
            }

            var playerIDs = filters.PlayerIDs;
            if (playerIDs != null && playerIDs.Any())
            {
                formData.Add("playerIDs", string.Join(",", playerIDs));
            }

            var totalRatings = filters.TotalRatings;
            if (totalRatings != null && totalRatings.Any())
            {
                formData.Add("totalRatings", string.Join(",", totalRatings.Select(c => (c.Key ?? string.Empty).Trim() + "=" + c.Value)));
            }

            var minRatings = filters.MinRating;
            if (minRatings != null && minRatings.Any())
            {
                formData.Add("rating", string.Join(",", minRatings.Select(c => (c.Key ?? string.Empty).Trim() + "=" + c.Value)));
            }
        }

        const string path = "/getbucketsaves.json";
        return Task.Run(() => Request.ExecuteRequest<CloudSavesResponse>(
            path,
            service,
            formData,
            paginationOptions
        )).Result;
    }

    /// <summary>
    /// Return paginated cloud saves within a bucket
    /// </summary>
    [UsedImplicitly]
    public static CloudSavesResponse GetCloudSaves(
        this CloudSaveService service,
        GameBucket bucket,
        PaginationOptions paginationOptions,
        Enums.GetBucketCloudSaveSortMethod? orderBy = null,
        GetBucketCloudSaveFilters filters = null)
        => GetCloudSaves(service, bucket.ID, paginationOptions, orderBy, filters);
}