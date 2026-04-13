using ConstructServices.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConstructServices.Achievements.Responses;

public sealed class PlayerAchievementsResponse : BaseResponse
{
    [JsonProperty(PropertyName = "playerAchievements")]
    public List<Objects.PlayerAchievement> PlayerAchievements { get; set; }

    public PlayerAchievementsResponse()
    {
    }
    public PlayerAchievementsResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}