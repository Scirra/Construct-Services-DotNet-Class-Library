using ConstructServices.Leaderboards.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using ConstructServices.Common;
using Pagination = ConstructServices.Leaderboards.Objects.Pagination;

namespace ConstructServices.Leaderboards.Responses;

public sealed class ListShadowBansResponse : BaseResponse
{
    [JsonProperty(PropertyName = "bans")]
    public List<ShadowBan> Bans { get; set; }

    [JsonProperty(PropertyName = "pagination")]
    public Pagination Pagination { get; set; }

    public ListShadowBansResponse()
    {
    }
    public ListShadowBansResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}