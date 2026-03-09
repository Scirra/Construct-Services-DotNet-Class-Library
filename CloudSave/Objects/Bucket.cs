using Newtonsoft.Json;
using System;

namespace ConstructServices.CloudSave.Objects;

public sealed class Bucket
{
    [JsonProperty(PropertyName = "id")]
    public Guid ID { get; private set; }

    [JsonProperty(PropertyName = "name")]
    public string Name { get; private set; }

    [JsonProperty(PropertyName = "created")]
    public DateTime Created { get; private set; }

    [JsonProperty(PropertyName = "accessMode")]
    public string AccessMode { get; private set; }

    [JsonProperty(PropertyName = "allowRatings")]
    public bool AllowRatings { get; private set; }

    [JsonProperty(PropertyName = "totalBlobs")]
    public int TotalCloudSaves { get; private set; }

    [JsonProperty(PropertyName = "totalBytes")]
    public long TotalBytes { get; private set; }

    [JsonProperty(PropertyName = "maxBlobSizeBytes")]
    public int MaxCloudSaveSizeBytes { get; private set; }

    [JsonProperty(PropertyName = "maxBlobs")]
    public int? MaxCloudSaves { get; private set; }

    [JsonProperty(PropertyName = "maxBlobsPerPlayer")]
    public short? MaxCloudSavesPerPlayer { get; private set; }

    public Bucket()
    {

    }
}