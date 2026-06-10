using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Broadcasts.Objects;

public sealed class HostedBroadcastURL
{
    [JsonProperty(PropertyName = "language")]
    public Language Language { get; private set; } 

    [JsonProperty(PropertyName = "url")]
    public string URL { get; set; }

    public HostedBroadcastURL()
    {
    }
}