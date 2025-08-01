using ConstructServices.Authentication.Objects;
using ConstructServices.Common;
using ConstructServices.Ratings.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConstructServices.CloudSave.Objects;

public class CloudSave
{
    [JsonProperty(PropertyName = "id")]
    public Guid ID { get; private set; }

    [JsonProperty(PropertyName = "key")]
    public string Key { get; private set; }

    [JsonProperty(PropertyName = "bucket")]
    public GameBucket Bucket { get; private set; }

    [JsonProperty(PropertyName = "player")]
    public Player Player { get; private set; }

    [JsonProperty(PropertyName = "name")]
    public string Name { get; private set; }

    [JsonProperty(PropertyName = "created")]
    public DateTime Created { get; private set; }

    [JsonProperty(PropertyName = "sizeBytes")]
    public int SizeBytes { get; private set; }

    [JsonProperty(PropertyName = "downloadURL")]
    public string DownloadURL { get; private set; }

    [JsonProperty(PropertyName = "rating")]
    public RatingAggregate Rating { get; set; }

    [JsonProperty(PropertyName = "myRating")]
    public Rating MyRating { get; set; }

    [JsonProperty(PropertyName = "slotRatings")]
    public Dictionary<string, RatingAggregate> SlotRatings { get; set; }

    [JsonProperty(PropertyName = "mySlotRatings")]
    public Dictionary<string, Rating> MySlotRatings { get; set; }

    [JsonProperty(PropertyName = "pictures")]
    public List<AvailablePicture> Pictures { get; set; }

    public CloudSave()
    {
    }
}