﻿using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using ConstructServices.Common;

namespace ConstructServices.Leaderboards.Responses
{
    public class GetShadowBansResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "bans")]
        public List<ShadowBan> Bans { get; set; }

        [JsonProperty(PropertyName = "pagination")]
        public Pagination Pagination { get; set; }

        public GetShadowBansResponse()
        {
        }
        public GetShadowBansResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
        {

        }
    }
}
