using Newtonsoft.Json;
using System;

namespace ConstructServices.CloudSave.Objects;

public sealed class GameBucket
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
    public int TotalBlobs { get; private set; }

    [JsonProperty(PropertyName = "totalBytes")]
    public long TotalBytes { get; private set; }

    [JsonProperty(PropertyName = "maxBlobSizeBytes")]
    public int MaxBlobSizeBytes { get; private set; }

    [JsonProperty(PropertyName = "maxBlobs")]
    public int MaxBlobs { get; private set; }

    [JsonProperty(PropertyName = "maxBlobsPerPlayer")]
    public short? MaxBlobsPerPlayer { get; private set; }

    public GameBucket()
    {

    }
}