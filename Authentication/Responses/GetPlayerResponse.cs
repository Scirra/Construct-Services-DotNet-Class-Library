using ConstructServices.Leaderboards.Responses;
using Newtonsoft.Json;
using ConstructServices.Authentication.Objects;

namespace ConstructServices.Authentication.Responses
{
    public class GetPlayerResponse : BaseResponse
    {        
        [JsonProperty(PropertyName = "player")]
        public Player Player { get; set; }
        public bool ShouldSerializePlayer() => Success;

        public GetPlayerResponse()
        {
        }
        public GetPlayerResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
        {

        }
    }
}
