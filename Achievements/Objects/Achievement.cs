using ConstructServices.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConstructServices.Achievements.Objects;

public sealed class Achievement
{ 
    [JsonProperty(PropertyName = "id")]
    public Guid ID { get; private set; }
    
    [JsonProperty(PropertyName = "created")]
    public DateTime Created { get; private set; }
    
    [JsonProperty(PropertyName = "formattedDateCreated")]
    public string FormattedDateCreated { get; private set; }
    
    [JsonProperty(PropertyName = "name")]
    public string Name { get; private set; }
    
    [JsonProperty(PropertyName = "description")]
    public string Description { get; private set; }

    [JsonProperty(PropertyName = "progressive")]
    public bool Progressive { get; private set; }

    [JsonProperty(PropertyName = "progressionRequired")]
    public long? ProgressionRequired { get; private set; }

    [JsonProperty(PropertyName = "originalLanguage")]
    public Language OriginalLanguage { get; private set; }
    
    [JsonProperty(PropertyName = "responseLanguage")]
    public Language ResponseLanguage { get; private set; }

    [JsonProperty(PropertyName = "isSecret")]
    public bool IsSecret { get; private set; }

    [JsonProperty(PropertyName = "achievedLogos")]
    public List<AvailablePicture> AchievedLogos { get; private set; }

    [JsonProperty(PropertyName = "unachievedLogos")]
    public List<AvailablePicture> UnachievedLogos { get; private set; }
    
    [JsonProperty(PropertyName = "maxUnlocks")]
    public int MaxUnlocks { get; private set; }
    
    [JsonProperty(PropertyName = "formattedMaxUnlocked")]
    public string FormattedMaxUnlocked { get; private set; }

    [JsonProperty(PropertyName = "xpBonuses")]
    public List<XPBonus> XPBonuses { get; private set; }
            
    [JsonProperty(PropertyName = "totalAwarded")]
    public int TotalAwarded { get; private set; }

    [JsonProperty(PropertyName = "formattedTotalAwarded")]
    public string FormattedTotalAwarded { get; private set; }
    
    [JsonProperty(PropertyName = "totalUniquePlayersAwarded")]
    public int TotalUniquePlayersAwarded { get; private set; }

    [JsonProperty(PropertyName = "formattedTotalUniquePlayersAwarded")]
    public string FormattedTotalUniquePlayersAwarded { get; private set; }

    [JsonProperty(PropertyName = "percentagePlayerBaseOwned")]
    public decimal PercentagePlayerBaseOwned { get; private set; }
    
    [JsonProperty(PropertyName = "firstAwarded")]
    public DateTime? FirstAwarded { get; private set; }
    
    [JsonProperty(PropertyName = "formattedFirstAwarded")]
    public string FormattedFirstAwarded { get; private set; }
    
    [JsonProperty(PropertyName = "formattedLastAwarded")]
    public string FormattedLastAwarded { get; private set; }
        
    [JsonProperty(PropertyName = "lastAwarded")]
    public DateTime? LastAwarded  { get; private set; }    
    
    [JsonProperty(PropertyName = "clientProgressAllowed")]
    public bool ClientProgressAllowed { get; private set; }

    public Achievement()
    {

    }
}
