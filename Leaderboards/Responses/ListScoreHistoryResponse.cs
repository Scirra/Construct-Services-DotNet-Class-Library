using ConstructServices.Authentication.Objects;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ConstructServices.Common.Countries;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Responses;

public sealed class ListScoreHistoryResponse : BaseResponse
{
    [JsonProperty(PropertyName = "scoreID")]
    public Guid ScoreID { get; set; }

    [JsonProperty(PropertyName = "player")]
    public Player Player { get; set; }

    [JsonProperty(PropertyName = "country")]
    public string CountryISOAlpha2 { get; set; }

    [UsedImplicitly]
    public Country Country()
        => Common.Countries.Functions.GetFromISOAlpha2(CountryISOAlpha2);

    [JsonProperty(PropertyName = "scoreHistory")]
    public List<ScoreHistory> ScoreHistory { get; set; }

    public ListScoreHistoryResponse()
    {
    }
    public ListScoreHistoryResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}