using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using Pagination = ConstructServices.Leaderboards.Objects.Pagination;

namespace ConstructServices.Leaderboards.Responses;

public sealed class ListTeamPlayersResponse : BaseResponse
{
    [JsonProperty(PropertyName = "pagination")]
    public Pagination Pagination { get; set; }

    [JsonProperty(PropertyName = "team")]
    public Team Team { get; set; }

    [JsonProperty(PropertyName = "players")]
    public List<TeamPlayer> Players { get; set; }

    public ListTeamPlayersResponse()
    {
    }
    public ListTeamPlayersResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}