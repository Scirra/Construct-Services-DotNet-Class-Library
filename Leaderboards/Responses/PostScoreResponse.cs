using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using JetBrains.Annotations;
using Newtonsoft.Json;
using System.Globalization;

namespace ConstructServices.Leaderboards.Responses;

public class PostScoreResponse : BaseResponse
{
    [JsonProperty(PropertyName = "formattingCulture")]
    private string FormattingCulture_ { get; set; }
    [UsedImplicitly] 
    public CultureInfo FormattingCulture => new(FormattingCulture_);

    [JsonProperty(PropertyName = "score")]
    private Score Score { get; set; }

    [JsonProperty(PropertyName = "leaderboard")]
    private Leaderboard Leaderboard { get; set; }

    [JsonProperty(PropertyName = "personalBest")]
    private bool PersonalBest { get; set; }

    public PostScoreResponse()
    {
    }
    public PostScoreResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {

    }
}