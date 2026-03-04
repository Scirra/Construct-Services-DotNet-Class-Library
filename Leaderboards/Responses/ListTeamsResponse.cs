using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using Pagination = ConstructServices.Leaderboards.Objects.Pagination;

namespace ConstructServices.Leaderboards.Responses;

public sealed class ListTeamsResponse : BaseResponse
{
    [JsonProperty(PropertyName = "pagination")]
    public Pagination Pagination { get; set; }

    [JsonProperty(PropertyName = "teams")]
    public List<Team> Teams { get; set; }

    public ListTeamsResponse()
    {
    }
    public ListTeamsResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}