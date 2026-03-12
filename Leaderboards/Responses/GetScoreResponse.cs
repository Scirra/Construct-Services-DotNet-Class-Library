using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;

namespace ConstructServices.Leaderboards.Responses
{
    public sealed class GetScoreResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "score")]
        public Score Score { get; set; }

        public GetScoreResponse()
        {
        }
        public GetScoreResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
        {

        }
    }
}
