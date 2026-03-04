using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;

namespace ConstructServices.Leaderboards.Responses;

public sealed class GetTeamResponse : BaseResponse
{
    [JsonProperty(PropertyName = "team")]
    public Team Team { get; set; }

    public GetTeamResponse()
    {
    }
    public GetTeamResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}