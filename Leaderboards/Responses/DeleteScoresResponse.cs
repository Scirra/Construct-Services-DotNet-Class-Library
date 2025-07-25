using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Leaderboards.Responses;

public class DeleteScoresResponse : BaseResponse
{
    [JsonProperty(PropertyName = "scoresDeleted")]
    public int ScoresDeleted { get; set; }

    [JsonProperty(PropertyName = "mightHaveMore")]
    public bool MightHaveMore { get; set; }

    public DeleteScoresResponse()
    {
    }
    public DeleteScoresResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {

    }
}