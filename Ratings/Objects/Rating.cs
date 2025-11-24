using System;
using Newtonsoft.Json;

namespace ConstructServices.Ratings.Objects;

public sealed class Rating
{
    [JsonProperty(PropertyName = "value")]
    public byte Value { get; set; }
    
    [JsonProperty(PropertyName = "maxRating")]
    public byte MaxRating { get; set; }

    [JsonProperty(PropertyName = "date")]
    public DateTime Date { get; set; }
    
    [JsonProperty(PropertyName = "formattedDate")]
    public string FormattedDate { get; set; }
    
    public Rating()
    {
    }
}