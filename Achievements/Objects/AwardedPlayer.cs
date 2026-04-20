using ConstructServices.Authentication.Objects;
using Newtonsoft.Json;
using System;

namespace ConstructServices.Achievements.Objects;
public sealed class AwardedPlayer
{
    [JsonProperty(PropertyName = "player")]
    public Player Player { get; private set; }    
    
    [JsonProperty(PropertyName = "awardedPlayerAchievement")]
    public AwardedPlayerAchievement AwardedPlayerAchievement { get; private set; }

    public AwardedPlayer()
    {    
    }
}
public sealed class AwardedPlayerAchievement
{
    [JsonProperty(PropertyName = "count")]
    public int Count { get; private set; }
    
    [JsonProperty(PropertyName = "formattedCount")]
    public string FormattedCount { get; private set; }

    [JsonProperty(PropertyName = "firstAwarded")]
    public DateTime? FirstAwarded { get; private set; }    
    
    [JsonProperty(PropertyName = "formattedFirstAwarded")]
    public string FormattedFirstAwarded { get; private set; }
    
    [JsonProperty(PropertyName = "lastAwarded")]
    public DateTime? LastAwarded { get; private set; }
    
    [JsonProperty(PropertyName = "formattedLastAwarded")]
    public string FormattedLastAwarded { get; private set; }
    
    [JsonProperty(PropertyName = "progress")]
    public long? Progress { get; private set; }
    
    [JsonProperty(PropertyName = "formattedProgress")]
    public string FormattedProgress { get; private set; }
    
    public AwardedPlayerAchievement()
    {

    }
}