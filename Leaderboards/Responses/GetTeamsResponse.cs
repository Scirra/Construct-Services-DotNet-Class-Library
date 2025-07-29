using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using JetBrains.Annotations;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using Pagination = ConstructServices.Leaderboards.Objects.Pagination;

namespace ConstructServices.Leaderboards.Responses;

public class GetTeamsResponse : BaseResponse
{
    [JsonProperty(PropertyName = "pagination")]
    public Pagination Pagination { get; set; }

    [JsonProperty(PropertyName = "formattingCulture")]
    private string FormattingCulture_ { get; set; }
    [UsedImplicitly] 
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