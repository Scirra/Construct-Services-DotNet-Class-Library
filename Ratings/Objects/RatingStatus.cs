using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConstructServices.Ratings.Objects;

public sealed class RatingStatus
{   
    [JsonProperty(PropertyName = "isRatable")]
    public bool IsRatable { get; set; }
        
    [JsonProperty(PropertyName = "ratings")]
    public Dictionary<string, RatingAggregate> Ratings { get; set; }
    public bool ShouldSerializeRatings() => IsRatable;

    [JsonProperty(PropertyName = "myRatings")]
    public Dictionary<string, Rating> MyRatings { get; set; }
    public bool ShouldSerializeMyRatings() => IsRatable;

    public RatingStatus()
    {

    }
}