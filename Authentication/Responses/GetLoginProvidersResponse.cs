using Newtonsoft.Json;
using System.Collections.Generic;
using ConstructServices.Authentication.Objects;
using ConstructServices.Common;

namespace ConstructServices.Authentication.Responses;

public sealed class GetConnectedLoginProvidersResponse : BaseResponse
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