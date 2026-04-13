using Newtonsoft.Json;
using System;

namespace ConstructServices.Achievements.Objects;

public sealed class PlayerAchievement
{ 
    [JsonProperty(PropertyName = "count")]
    public int Count { get; private set; }

    [JsonProperty(PropertyName = "firstAwarded")]
    public DateTime? FirstAwarded { get; private set; }
    
    [JsonProperty(PropertyName = "lastAwarded")]
    public DateTime? LastAwarded { get; private set; }
    
    [JsonProperty(PropertyName = "progress")]
    public long? Progress { get; private set; }
    
    [JsonProperty(PropertyName = "achievement")]
    public Achievement Achievement { get; private set; }
    
    public PlayerAchievement()
    {

    }
}
