using System;
using ConstructServices.CloudSave.Enums;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Collections.Generic;

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