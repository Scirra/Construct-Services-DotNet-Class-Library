using ConstructServices.Achievements.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Achievements;

public static partial class Actions
{
    extension(AchievementServiceBase service)
    {
        /// <summary>
        /// Get an existing Achievement
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/get-achievement" />
        [UsedImplicitly]
        public AchievementResponse GetAchievement(Guid achievementID)
        {
            return Request.ExecuteSyncRequest<AchievementResponse>(
                Config.EndPointPaths.Get,
                service,
                GetAchievementOptions.BuildFormData(achievementID)
            );
        }

        /// <summary>
        /// Get an existing Achievement
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/get-achievement" />
        [UsedImplicitly]
        public async Task<AchievementResponse> GetAchievementAsync(Guid achievementID)
        {
            return await Request.ExecuteAsyncRequest<AchievementResponse>(
                Config.EndPointPaths.Get,
                service,
                GetAchievementOptions.BuildFormData(achievementID)
            );
        }
    }
    
    private static class GetAchievementOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid achievementID)
        {
            return new Dictionary<string, string>
            {
                { "achievementID", achievementID.ToString() }
            };
        }
    }
}