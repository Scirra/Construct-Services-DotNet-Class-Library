using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using ConstructServices.Common;

namespace ConstructServices.Leaderboards.Responses;

public sealed class GetScoreNeighboursResponse : BaseResponse
{
    [JsonProperty(PropertyName = "scores")]
    public List<Score> Scores { get; set; }

    public GetScoreNeighboursResponse()
    {
    }
    public GetScoreNeighboursResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}