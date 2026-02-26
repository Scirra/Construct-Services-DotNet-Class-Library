using ConstructServices.Common;
using ConstructServices.XP.Objects;
using Newtonsoft.Json;

namespace ConstructServices.XP.Responses;

public sealed class XPResponse : BaseResponse
{
    [JsonProperty(PropertyName = "xp")]
    public long XP { get; set; }

    [JsonProperty(PropertyName = "formattedXP")]
    public string FormattedXP { get; set; }

    [JsonProperty(PropertyName = "rank")]
    public XPRank Rank { get; set; }

    [JsonProperty(PropertyName = "nextRank")]
    public XPRank NextRank { get; set; }

    public XPResponse()
    {
    }
    public XPResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}