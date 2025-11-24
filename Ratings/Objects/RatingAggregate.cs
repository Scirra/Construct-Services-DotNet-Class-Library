using Newtonsoft.Json;
using System;

namespace ConstructServices.Ratings.Objects;

public sealed class RatingAggregate
{
    [JsonProperty(PropertyName = "totalRatings")]
    public int TotalRatings { get; set; }

    [JsonProperty(PropertyName = "averageRating")]
    public decimal AverageRating { get; set; }

    [JsonProperty(PropertyName = "lastRating")]
    public DateTime? LastRating { get; set; }

    public RatingAggregate()
    {
    }
}