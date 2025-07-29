using Newtonsoft.Json;

namespace ConstructServices.Ratings.Objects;

public class RatingSlot
{
    [JsonProperty(PropertyName = "id")] 
    public string ID { get; set; }

    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }

    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    [JsonProperty(PropertyName = "maxRating")]
    public byte MaxRating { get; set; }

    [JsonProperty(PropertyName = "rating")]
    public RatingAggregate Rating { get; set; }

    public RatingSlot()
    {
    }
}