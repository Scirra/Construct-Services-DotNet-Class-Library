using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConstructServices.Authentication.Objects;

public sealed class PatreonMetaData
{    
    [JsonProperty(PropertyName = "memberships")]
    public List<PatreonMembership> Memberships { get; set; }

    public PatreonMetaData()
    {

    }
}

public sealed class PatreonMembership
{    
    [JsonProperty(PropertyName = "id")]
    public string ID { get; set; }

    [JsonProperty(PropertyName = "lifetimeSupportCents")]
    public long LifetimeSupportCents { get; set; }

    [JsonProperty(PropertyName = "currentlyEntitledAmountCents")]
    public long CurrentlyEntitledAmountCents { get; set; }

    [JsonProperty(PropertyName = "campaign")]
    public PatreonCampaign Campaign { get; set; }

    [JsonProperty(PropertyName = "currentlyEntitledTiers")]
    public List<PatreonTier> CurrentlyEntitledTiers { get; set; }

    public PatreonMembership()
    {

    }
}

public sealed class PatreonCampaign
{
    [JsonProperty(PropertyName = "id")]
    public string ID { get; set; }

    [JsonProperty(PropertyName = "vanity")]
    public string Vanity { get; set; }

    [JsonProperty(PropertyName = "creationName")]
    public string CreationName { get; set; }

    [JsonProperty(PropertyName = "url")]
    public string URL { get; set; }

    public PatreonCampaign()
    {

    }
}

public sealed class PatreonTier
{
    [JsonProperty(PropertyName = "id")]
    public string ID { get; set; }

    [JsonProperty(PropertyName = "title")]
    public string Title { get; set; }

    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    public PatreonTier()
    {

    }
}