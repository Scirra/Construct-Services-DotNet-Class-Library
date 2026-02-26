using ConstructServices.Common;
using ConstructServices.XP.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConstructServices.XP.Responses;

public sealed class BonusesResponse : BaseResponse
{
    [JsonProperty(PropertyName = "bonuses")]
    public List<XPBonus> Bonuses { get; set; }

    public BonusesResponse()
    {
    }
    public BonusesResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}