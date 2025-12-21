using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using JetBrains.Annotations;
using Newtonsoft.Json;
using System.Globalization;

namespace ConstructServices.Leaderboards.Responses;

public sealed class GetTeamResponse : BaseResponse
{
    [JsonProperty(PropertyName = "formattingCulture")]
    private string FormattingCulture_ { get; set; }
    [UsedImplicitly] 
    public CultureInfo FormattingCulture => new(FormattingCulture_);

    [JsonProperty(PropertyName = "team")]
    public Team Team { get; set; }

    public GetTeamResponse()
    {
    }
    public GetTeamResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {

    }
}