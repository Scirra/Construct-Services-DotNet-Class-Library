using ConstructServices.Common;
using ConstructServices.XP.Objects;
using Newtonsoft.Json;

namespace ConstructServices.XP.Responses;

public sealed class RankResponse : BaseResponse
{
    [JsonProperty(PropertyName = "rank")]
    public XPRank Rank { get; set; }

    public RankResponse()
    {
    }
    public RankResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}