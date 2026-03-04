using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;

namespace ConstructServices.Leaderboards.Responses;

public sealed class TeamResponse : BaseResponse
{
    [JsonProperty(PropertyName = "team")]
    public Team Team { get; set; }

    public TeamResponse()
    {
    }
    public TeamResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}