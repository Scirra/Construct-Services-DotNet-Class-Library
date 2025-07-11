using ConstructServices.Authentication.Objects;
using ConstructServices.Leaderboards.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConstructServices.Authentication.Responses;

public class RegisterPlayerResponse : BaseResponse
{
    [JsonProperty(PropertyName = "player")] 
    public List<Player> ConnectedProviders { get; set; }

    public RegisterPlayerResponse()
    {
    }
    public RegisterPlayerResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {
    }
}