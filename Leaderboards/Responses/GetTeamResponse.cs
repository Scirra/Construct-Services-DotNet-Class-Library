using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;
using System.Globalization;
using ConstructServices.Common;

namespace ConstructServices.Leaderboards.Responses
{
    public class GetTeamResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "formattingCulture")]
        private string FormattingCulture_ { get; set; }
        public CultureInfo FormattingCulture => new(FormattingCulture_);

        [JsonProperty(PropertyName = "team")]
        public Team Team { get; set; }

        public GetTeamResponse()
        {
        }
        public GetTeamResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
        {

        }
    }
}
