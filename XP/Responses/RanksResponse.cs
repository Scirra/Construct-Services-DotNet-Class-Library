using ConstructServices.Common;
using ConstructServices.XP.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConstructServices.XP.Responses;

public sealed class RanksResponse : BaseResponse
{
    [JsonProperty(PropertyName = "ranks")]
    public List<XPRank> Ranks { get; set; }

    public RanksResponse()
    {
    }
    public RanksResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}