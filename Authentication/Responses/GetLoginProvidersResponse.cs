using ConstructServices.Leaderboards.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;
using ConstructServices.Authentication.Objects;

namespace ConstructServices.Authentication.Responses;

public class GetConnectedLoginProvidersResponse : BaseResponse
{
    [JsonProperty(PropertyName = "connectedProviders")] 
    public List<PlayerLoginProvider> ConnectedProviders { get; set; }

    public GetConnectedLoginProvidersResponse()
    {
    }
    public GetConnectedLoginProvidersResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {
    }
}