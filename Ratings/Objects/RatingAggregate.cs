using Newtonsoft.Json;
using System;

namespace ConstructServices.Ratings.Objects;

public sealed class RatingAggregate
{
    [JsonProperty(PropertyName = "totalRatings")]
    public int TotalRatings { get; set; }

    [JsonProperty(PropertyName = "formattedTotalRatings")]
    public string FormattedTotalRatings { get; set; }
    
    [JsonProperty(PropertyName = "averageRating")]
    public decimal AverageRating { get; set; }
    
    [JsonProperty(PropertyName = "formattedAverageRating")]
    public string FormattedAverageRating { get; set; }
    
    [JsonProperty(PropertyName = "maxRating")]
    public byte MaxRating { get; set; }
    
    [JsonProperty(PropertyName = "lastRating")]
    public DateTime? LastRating { get; set; }
    
    [JsonProperty(PropertyName = "formattedLastRating")]
    public string FormattedLastRating { get; set; }

    public RatingAggregate()
    {
    }
}