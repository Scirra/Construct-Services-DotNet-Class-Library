using ConstructServices.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConstructServices.Achievements.Responses;

public sealed class AchievementsResponse : BaseResponse
{
    [JsonProperty(PropertyName = "achievements")]
    public List<Objects.Achievement> Achievements { get; set; }

    public AchievementsResponse()
    {
    }
    public AchievementsResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}