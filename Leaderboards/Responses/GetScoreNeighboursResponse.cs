using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;

namespace ConstructServices.Leaderboards.Responses
{
    public class GetScoreNeighboursResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "formattingCulture")]
        private string FormattingCulture_ { get; set; }
        public CultureInfo FormattingCulture => new(FormattingCulture_);

        [JsonProperty(PropertyName = "scores")]
        public List<Score> Scores { get; set; }

        public GetScoreNeighboursResponse()
        {
        }
        public GetScoreNeighboursResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
        {

        }
    }
}
