using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConstructServices.Ratings.Objects;

public sealed class RatingStatus
{   
    [JsonProperty(PropertyName = "isRateable")]
    public bool IsRateable { get; set; }
        
    [JsonProperty(PropertyName = "ratings")]
    public Dictionary<string, RatingAggregate> Ratings { get; set; }
    public bool ShouldSerializeRatings() => IsRateable;

    [JsonProperty(PropertyName = "myRatings")]
    public Dictionary<string, Rating> MyRatings { get; set; }
    public bool ShouldSerializeMyRatings() => IsRateable;

    public RatingStatus()
    {

    }
}