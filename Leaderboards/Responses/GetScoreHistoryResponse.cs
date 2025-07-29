using ConstructServices.Authentication.Objects;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConstructServices.Leaderboards.Responses;

public class GetScoreHistoryResponse : BaseResponse
{
    [JsonProperty(PropertyName = "scoreID")]
    public Guid ScoreID { get; set; }

    [JsonProperty(PropertyName = "player")]
    public Player Player { get; set; }

    [JsonProperty(PropertyName = "country")]
    public string Country { get; set; }

    [JsonProperty(PropertyName = "formattingCulture")]
    private string FormattingCulture_ { get; set; }
    [UsedImplicitly] 
    public CultureInfo FormattingCulture => new(FormattingCulture_);

    [JsonProperty(PropertyName = "scoreHistory")]
    public List<ScoreHistory> ScoreHistory { get; set; }

    public GetScoreHistoryResponse()
    {
    }
    public GetScoreHistoryResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {

    }
}