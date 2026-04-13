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
        /// List all players Achievements
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/list-player-achievements" />
        [UsedImplicitly]
        public PlayerAchievementsResponse ListPlayerAchievements(Guid playerID)
        {
            return Request.ExecuteSyncRequest<PlayerAchievementsResponse>(
                Config.EndPointPaths.ListPlayerAchievements,
                service,
                ListPlayerAchievementsOptions.BuildFormData(playerID)
            );
        }

        /// <summary>
        /// List all players Achievements
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/list-player-achievements" />
        [UsedImplicitly]
        public async Task<PlayerAchievementsResponse> ListPlayerAchievementsAsync(Guid playerID)
        {
            return await Request.ExecuteAsyncRequest<PlayerAchievementsResponse>(
                Config.EndPointPaths.ListPlayerAchievements,
                service,
                ListPlayerAchievementsOptions.BuildFormData(playerID)
            );
        }
    }

    private static class ListPlayerAchievementsOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid playerID)
        {
            var formData = new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() }
            };
            return formData;
        }
    }
}