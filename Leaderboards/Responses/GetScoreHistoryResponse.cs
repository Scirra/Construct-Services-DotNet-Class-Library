using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
namespace ConstructServices.Leaderboards.Responses
{
    public class GetScoreHistoryResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "scoreID")]
        public Guid ScoreID { get; set; }

        [JsonProperty(PropertyName = "playerIdentifier")]
        public string PlayerIdentifier { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "formattingCulture")]
        private string FormattingCulture_ { get; set; }
        public CultureInfo FormattingCulture => new(FormattingCulture_);

        [JsonProperty(PropertyName = "scoreHistory")]
        public List<ScoreHistory> ScoreHistory { get; set; }

        public GetScoreHistoryResponse()
        {
        }
        public GetScoreHistoryResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
        {

        }
    }
}
