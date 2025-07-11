using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using ConstructServices.Common;

namespace ConstructServices.Leaderboards.Responses
{
    public class GetTeamsResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty(PropertyName = "formattingCulture")]
        private string FormattingCulture_ { get; set; }
        public CultureInfo FormattingCulture => new(FormattingCulture_);

        [JsonProperty(PropertyName = "teams")]
        public List<Team> Teams { get; set; }

        public GetTeamsResponse()
        {
        }
        public GetTeamsResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
        {

        }
    }
}
