using ConstructServices.CloudSave.Enums;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructServices.CloudSave.Objects;

public abstract class ModifyBucketBase
{        
    [UsedImplicitly]
    public string Name { get; set; }

    [UsedImplicitly]
    public CloudSaveGameBucketAccessMode AccessMode { get; set; }

    [UsedImplicitly]
    public bool AllowRatings { get; set; }

    [UsedImplicitly]
    public uint? MaxBlobs { get; set; }

    [UsedImplicitly]
    public uint? MaxBlobSizeBytes { get; set; }

    [UsedImplicitly]
    public uint? MaxBlobsPerPlayer { get; set; }

    protected Dictionary<string, string> BuildBaseFormData() => new()
    {
        { "bucketName", Name },
        { "accessMode", AccessMode.ToString() },
        { "allowRatings", AllowRatings.ToInt().ToString() },
        { "maxBlobs", MaxBlobs.ToString() },
        { "maxBlobSize", MaxBlobSizeBytes.ToString() },
        { "maxBlobsPerPlayer", MaxBlobsPerPlayer.ToString() }
    };
}
public sealed class CreateBucketOptions : ModifyBucketBase
{
    public CreateBucketOptions(
        string name,
        CloudSaveGameBucketAccessMode accessMode,
        bool allowRatings = true,
        uint? maxBlobs = null,
        uint? maxBlobSizeBytes = null,
        uint? maxBlobsPerPlayer = null)
    {
        Name = name;
        AccessMode = accessMode;
        AllowRatings = allowRatings;
        MaxBlobs = maxBlobs;
        MaxBlobSizeBytes = maxBlobSizeBytes;
        MaxBlobsPerPlayer = maxBlobsPerPlayer;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = BuildBaseFormData();
        return formData;
    }
}
public sealed class GetBucketOptions
{
    [UsedImplicitly]
    public Guid BucketID { get; private set; }
    
    public GetBucketOptions(string strBucketID)
    {
        BucketID = Guid.Parse(strBucketID);
    }
    public GetBucketOptions(Guid bucketID)
    {
        BucketID = bucketID;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "bucketID", BucketID.ToString() }
        };
        return formData;
    }
}
public sealed class UpdateBucketOptions : ModifyBucketBase
{    
    [UsedImplicitly]
    public Guid BucketID { get; private set; }
    
    public UpdateBucketOptions(string strBucketID)
    {
        BucketID = Guid.Parse(strBucketID);
    }
    public UpdateBucketOptions(Guid bucketID)
    {
        BucketID = bucketID;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "bucketID", BucketID.ToString() }
        };
        return formData;
    }
}
public sealed class DeleteBucketOptions
{
    [UsedImplicitly]
    public Guid BucketID { get; private set; }
    
    public DeleteBucketOptions(string strBucketID)
    {
        BucketID = Guid.Parse(strBucketID);
    }
    public DeleteBucketOptions(Guid bucketID)
    {
        BucketID = bucketID;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "bucketID", BucketID.ToString() }
        };
        return formData;
    }
}
public sealed class ListBucketOptions
{
    [UsedImplicitly]
    public GetBucketsSortMethod? SortBy { get; private set; }
    
    public ListBucketOptions(GetBucketsSortMethod sortBy)
    {
        SortBy = sortBy;
    }
    public ListBucketOptions()
    {
    }

    [UsedImplicitly]
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

public sealed class GetBucketCloudSaveFilters
{
    public string Name { get; [UsedImplicitly] set; }
    public string Key { get; [UsedImplicitly] set; }
    public HashSet<Guid> PlayerIDs { get; [UsedImplicitly] set; }
    public Dictionary<string, int> TotalRatings { get; [UsedImplicitly] set; }
    public Dictionary<string, byte> MinRating { get; [UsedImplicitly] set; }
    public HashSet<Guid> BlobIDs { get; [UsedImplicitly] set; }
}

public sealed class ListBucketSavesOptions
{
    [UsedImplicitly]
    public Guid BucketID { get; private set; }

    [UsedImplicitly]
    public GetBucketsSortMethod? SortBy { get; private set; }

    [UsedImplicitly]
    public GetBucketCloudSaveFilters? Filters { get; private set; }
    
    public ListBucketSavesOptions(
        Guid bucketID, 
        GetBucketsSortMethod? sortBy = null,
        GetBucketCloudSaveFilters filters = null)
    {
        BucketID = bucketID;
        SortBy = sortBy;
        Filters = filters;
    }
    public ListBucketSavesOptions(
        string strBucketID, 
        GetBucketsSortMethod? sortBy = null,
        GetBucketCloudSaveFilters filters = null)
    {
        BucketID = Guid.Parse(strBucketID);
        SortBy = sortBy;
        Filters = filters;
    }
    public ListBucketSavesOptions(
        GameBucket bucket, 
        GetBucketsSortMethod? sortBy = null,
        GetBucketCloudSaveFilters filters = null)
    {
        BucketID = bucket.ID;
        SortBy = sortBy;
        Filters = filters;
    }

    [UsedImplicitly]
    internal Dictionary<string, string> BuildFormData()
    {
        var formData = new Dictionary<string, string>
        {
            { "mode", "Bucket" },
            { "bucketID", BucketID.ToString() }
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