using ConstructServices.Authentication.Objects;
using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Authentication.Responses
{
    public class GetPlayerResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "player")]
        public Player Player { get; set; }
        
        public GetPlayerResponse()
        {
        }
        public GetPlayerResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
        {

        }
    }
}
