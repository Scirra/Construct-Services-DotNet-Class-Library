using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;

namespace ConstructServices.Leaderboards.Responses;

public sealed class CreateScoreResponse : BaseResponse
{
    [JsonProperty(PropertyName = "score")]
    private Score Score { get; set; }

    [JsonProperty(PropertyName = "leaderboard")]
    private Leaderboard Leaderboard { get; set; }

    [JsonProperty(PropertyName = "personalBest")]
    private bool PersonalBest { get; set; }

    public CreateScoreResponse()
    {
    }
    public CreateScoreResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}