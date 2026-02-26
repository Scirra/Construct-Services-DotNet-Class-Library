using ConstructServices.Common;
using ConstructServices.XP.Objects;
using Newtonsoft.Json;

namespace ConstructServices.XP.Responses;

public sealed class BonusResponse : BaseResponse
{
    [JsonProperty(PropertyName = "bonus")]
    public XPBonus Rank { get; set; }

    public BonusResponse()
    {
    }
    public BonusResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}