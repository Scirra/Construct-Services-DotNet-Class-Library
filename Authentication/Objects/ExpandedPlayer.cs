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
            var r = new HashSet<PlayerRestriction>();
            foreach (var restriction in RestrictedActionIDs.Where(c => Enum.IsDefined(typeof(PlayerRestriction), c))
                         .Select(c => (PlayerRestriction)c))
            {
                r.Add(restriction);
            }
            return r;
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
        
    [JsonProperty(PropertyName = "totalPrivateCloudSaves")]
    public int TotalPrivateCloudSaves { get; set; }

    [JsonProperty(PropertyName = "totalPrivateCloudSavesSize")]
    public long TotalPrivateCloudSavesSize { get; set; }

    [JsonProperty(PropertyName = "totalBucketCloudSaves")]
    public int TotalBucketCloudSaves { get; set; }

    [JsonProperty(PropertyName = "totalBucketCloudSavesSize")]
    public long TotalBucketCloudSavesSize { get; set; }

    [JsonProperty(PropertyName = "totalRatings")]
    public int TotalRatings { get; set; }

    [JsonProperty(PropertyName = "totalRatingsValue")]
    public long TotalRatingsValue { get; set; }

    [JsonProperty(PropertyName = "averageRatingPercent")]
    public decimal AverageRatingPercent { get; set; }    
    
    [JsonProperty(PropertyName = "lastActive")]
    internal DateTime? LastActive { get; set; }

    public ExpandedPlayer()
    {

    }
}