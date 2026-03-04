using ConstructServices.Authentication.Objects;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConstructServices.Leaderboards.Responses;

public sealed class GetScoreHistoryResponse : BaseResponse
{
    [JsonProperty(PropertyName = "scoreID")]
    public Guid ScoreID { get; set; }

    [JsonProperty(PropertyName = "player")]
    public Player Player { get; set; }

    [JsonProperty(PropertyName = "country")]
    public string Country { get; set; }

    [JsonProperty(PropertyName = "scoreHistory")]
    public List<ScoreHistory> ScoreHistory { get; set; }

    public GetScoreHistoryResponse()
    {
    }
    public GetScoreHistoryResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}