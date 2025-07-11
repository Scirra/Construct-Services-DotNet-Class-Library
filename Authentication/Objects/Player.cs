using Newtonsoft.Json;
using System;

namespace ConstructServices.Authentication.Objects;

public class Player
{
    [JsonProperty(PropertyName = "id")]
    public Guid ID { get; private set; }

    [JsonProperty(PropertyName = "playerName")]
    public string PlayerName { get; private set; }
    
    [JsonProperty(PropertyName = "created")]
    public DateTime Created { get; private set; }
    
    [JsonProperty(PropertyName = "avatar")]
    public string Avatar { get; private set; }

    public Player()
    {

    }
}
