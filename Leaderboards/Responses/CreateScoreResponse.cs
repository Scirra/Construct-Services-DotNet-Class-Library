using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;

namespace ConstructServices.Leaderboards.Responses;

public sealed class CreateScoreResponse : BaseResponse
{
    [JsonProperty(PropertyName = "score")]
    public Score Score { get; set; }

    [JsonProperty(PropertyName = "leaderboard")]
    public Leaderboard Leaderboard { get; set; }

    [JsonProperty(PropertyName = "personalBest")]
    public bool PersonalBest { get; set; }

    public CreateScoreResponse()
    {
    }
    public CreateScoreResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}