using ConstructServices.Common;
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

    [JsonProperty(PropertyName = "averageRatingAsPercentage")]
    public decimal AverageRatingAsPercentage { get; set; }

    [JsonProperty(PropertyName = "formattedAverageRating")]
    public string FormattedAverageRating { get; set; }
    
    [JsonProperty(PropertyName = "maxRating")]
    public byte MaxRating { get; set; }
    
    [JsonProperty(PropertyName = "lastRating")]
    public DateTime? LastRating { get; set; }
    
    [JsonProperty(PropertyName = "formattedLastRating")]
    public string FormattedLastRating { get; set; }
    
    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }
    
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }
    
    [JsonProperty(PropertyName = "originalLanguage")]
    public Language OriginalLanguage { get; private set; }
    
    [JsonProperty(PropertyName = "responseLanguage")]
    public Language ResponseLanguage { get; private set; }

    public RatingAggregate()
    {
    }
}