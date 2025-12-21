using ConstructServices.Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using ConstructServices.Authentication.Objects;

namespace ConstructServices.Authentication.Responses;

public sealed class GetPlayersResponse : BaseResponse
{
    [JsonProperty(PropertyName = "pagination")]
    public Pagination Pagination { get; set; }

    [JsonProperty(PropertyName = "players")]
    public List<ExpandedPlayer> Players { get; set; }

    public GetPlayersResponse()
    {
    }
    public GetPlayersResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {

    }
}