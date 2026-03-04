using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using Pagination = ConstructServices.Leaderboards.Objects.Pagination;

namespace ConstructServices.Leaderboards.Responses;

public sealed class ScoresResponse : BaseResponse
{
    [JsonProperty(PropertyName = "pagination")]
    public Pagination Pagination { get; set; }

    [JsonProperty(PropertyName = "scores")]
    public List<Score> Scores { get; set; }

    public ScoresResponse()
    {
    }
    public ScoresResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}