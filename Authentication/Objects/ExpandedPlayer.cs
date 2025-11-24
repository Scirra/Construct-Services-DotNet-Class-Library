using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using ConstructServices.Authentication.Enums;
using ConstructServices.Common;

namespace ConstructServices.Authentication.Objects;

public sealed class ExpandedPlayer
{
    [JsonProperty(PropertyName = "id")]
    public Guid ID { get; set; }
        
    [JsonProperty(PropertyName = "playerName")]
    public string PlayerName { get; set; }
        
    [JsonProperty(PropertyName = "created")]
    public DateTime Created { get; set; }

    [JsonProperty(PropertyName = "successfulSignIns")]
    public int SuccessfulSignIns { get; set; }

    [JsonProperty(PropertyName = "lastSuccessfulSignIn")]
    public DateTime? LastSuccessfulSignIn { get; set; }
        
    [JsonProperty(PropertyName = "avatars")]
    public List<AvailablePicture> Avatars { get; set; }
        
    [JsonProperty(PropertyName = "loginProviders")]
    public List<PlayerLoginProvider> LoginProviders { get; set; }
        
    [JsonProperty(PropertyName = "restrictedActionIDs")]
    public HashSet<int> RestrictedActionIDs { get; set; }
    public bool ShouldSerializeRestrictedActionIDs() => false; 

    [JsonProperty(PropertyName = "restrictedActions")]
    public HashSet<PlayerRestriction> RestrictedActions {
        get
        {
            if (!RestrictedActionIDs.Any()) return [];
            return RestrictedActionIDs.Where(c => Enum.IsDefined(typeof(PlayerRestriction), c))
                .Select(c => (PlayerRestriction)c).ToHashSet();
        }
        // ReSharper disable once ValueParameterNotUsed
        set{}
    }
        
    [JsonProperty(PropertyName = "leaderboardScores")]
    public int LeaderboardScores { get; set; }
        
    [JsonProperty(PropertyName = "totalCloudSaves")]
    public int TotalCloudSaves { get; set; }

    [JsonProperty(PropertyName = "totalCloudSavesSize")]
    public long TotalCloudSavesSize { get; set; }

    [JsonProperty(PropertyName = "totalRatings")]
    public int TotalRatings { get; set; }

    [JsonProperty(PropertyName = "totalRatingsValue")]
    public long TotalRatingsValue { get; set; }

    [JsonProperty(PropertyName = "averageRatingPercent")]
    public decimal AverageRatingPercent { get; set; }

    public ExpandedPlayer()
    {

    }
}