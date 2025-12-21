using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Ratings.Objects;

public sealed class RatingDimension
{
    [JsonProperty(PropertyName = "id")] 
    public string ID { get; set; }

    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }

    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    [JsonProperty(PropertyName = "maxRating")]
    public byte MaxRating { get; set; }
    
    [JsonProperty(PropertyName = "originalLanguage")]
    public Language OriginalLanguage { get; private set; }
    
    [JsonProperty(PropertyName = "responseLanguage")]
    public Language ResponseLanguage { get; private set; }

    public RatingDimension()
    {
    }
}