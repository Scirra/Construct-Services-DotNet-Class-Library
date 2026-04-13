using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Achievements.Responses;

public sealed class AchievementResponse : BaseResponse
{
    [JsonProperty(PropertyName = "achievement")]
    public Objects.Achievement Achievement { get; set; }

    public AchievementResponse()
    {
    }
    public AchievementResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}