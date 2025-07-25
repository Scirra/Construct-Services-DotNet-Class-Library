using Newtonsoft.Json;

namespace ConstructServices.Leaderboards.Objects;

public class Tier
{
    [JsonProperty(PropertyName = "id")]
    public string ID { get; private set; }

    [JsonProperty(PropertyName = "name")]
    public string Name { get; private set; }

    public Tier()
    {

    }
}