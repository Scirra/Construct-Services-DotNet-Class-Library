using ConstructServices.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConstructServices.Authentication.Objects;

public sealed class Session
{
    [JsonProperty(PropertyName = "playerID")]
    public Guid PlayerID { get; set; }

    [JsonProperty(PropertyName = "playerName")]
    public string PlayerName { get; set; }

    [JsonProperty(PropertyName = "gameID")]
    public Guid GameID { get; set; }

    [JsonProperty(PropertyName = "key")]
    public string Key { get; set; }

    [JsonProperty(PropertyName = "expiry")]
    public DateTime Expiry { get; set; }
        
    [JsonProperty(PropertyName = "avatars")]
    public List<AvailablePicture> Avatars { get; set; }

    public Session()
    {
    }
}