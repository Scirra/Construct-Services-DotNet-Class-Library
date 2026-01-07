using Newtonsoft.Json;
using System;

namespace ConstructServices.Authentication.Objects;

public sealed class PlayerLoginProvider
{
    [JsonProperty(PropertyName = "playerID")]
    public Guid PlayerID { get; set; }

    [JsonProperty(PropertyName = "providerID")]
    public byte ProviderID { get; set; }

    [JsonProperty(PropertyName = "provider")]
    public string Provider { get; private set; }

    [JsonProperty(PropertyName = "username")]
    public string Username { get; private set; }

    [JsonProperty(PropertyName = "avatarURL")]
    public string AvatarURL { get; private set; }
        
    [JsonProperty(PropertyName = "signIns")]
    public int SignIns { get; private set; }

    [JsonProperty(PropertyName = "firstSignIn")]
    public DateTime FirstSignIn { get; private set; }

    [JsonProperty(PropertyName = "lastSignIn")]
    public DateTime LastSignIn { get; private set; }

    [JsonProperty(PropertyName = "metaData1")]
    public string MetaData1 { get; private set; }    
    
    [JsonProperty(PropertyName = "patreonMetaData")]
    public PatreonMetaData PatreonMetaData { get; private set; }  

    public PlayerLoginProvider()
    {
    }
}