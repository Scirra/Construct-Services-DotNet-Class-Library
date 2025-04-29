using Newtonsoft.Json;
using System;

namespace ConstructServices.Leaderboards.Responses
{
    public class CreateTeamResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "id")]
        public Guid TeamID { get; set; }

        public CreateTeamResponse()
        {
        }

        public CreateTeamResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
        {

        }
    }
}
