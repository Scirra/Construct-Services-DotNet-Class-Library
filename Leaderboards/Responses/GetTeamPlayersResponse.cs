﻿using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using ConstructServices.Common;

namespace ConstructServices.Leaderboards.Responses
{
    public class GetTeamPlayersResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty(PropertyName = "formattingCulture")]
        private string FormattingCulture_ { get; set; }
        public CultureInfo FormattingCulture => new(FormattingCulture_);

        [JsonProperty(PropertyName = "team")]
        public Team Team { get; set; }

        [JsonProperty(PropertyName = "players")]
        public List<TeamPlayer> Players { get; set; }

        public GetTeamPlayersResponse()
        {
        }
        public GetTeamPlayersResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
        {

        }
    }
}
