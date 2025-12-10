using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Leaderboards.Objects;

public sealed class Tier
{
    [JsonProperty(PropertyName = "id")]
    public string ID { get; private set; }

    [JsonProperty(PropertyName = "name")]
    public string Name { get; private set; }
    
    [JsonProperty(PropertyName = "responseLanguage")]
    public Language ResponseLanguage { get; private set; }

    public Tier()
    {

    }
}