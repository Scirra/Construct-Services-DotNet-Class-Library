using ConstructServices.Achievements.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Achievements;
public static partial class Actions
{
    extension(AchievementServiceBase service)
    {
        /// <summary>
        /// List all Achievements
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/list-achievements" />
        [UsedImplicitly]
        public AchievementsResponse ListAchievements()
        {
            return Request.ExecuteSyncRequest<AchievementsResponse>(
                Config.EndPointPaths.List,
                service,
                new Dictionary<string, string>()
            );
        }

        /// <summary>
        /// List all Achievements
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/list-achievements" />
        [UsedImplicitly]
        public async Task<AchievementsResponse> ListAchievementsAsync()
        {
            return await Request.ExecuteAsyncRequest<AchievementsResponse>(
                Config.EndPointPaths.List,
                service,
                new Dictionary<string, string>()
            );
        }
    }
}