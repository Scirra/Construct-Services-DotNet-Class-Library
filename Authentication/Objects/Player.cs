using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ConstructServices.Common;

namespace ConstructServices.Authentication.Objects;

public sealed class Player
{
    [JsonProperty(PropertyName = "id")]
    public Guid ID { get; private set; }

    [JsonProperty(PropertyName = "playerName")]
    public string PlayerName { get; private set; }
    
    [JsonProperty(PropertyName = "created")]
    public DateTime Created { get; private set; }

    [JsonProperty(PropertyName = "avatars")]
    public List<AvailablePicture> Avatars { get; private set; }

    public Player()
    {

    }
}
