using ConstructServices.Achievements.Enums;
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
        /// List all players awarded an achievement
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/list-awarded-players" />
        [UsedImplicitly]
        public AwardedPlayersResponse ListAwardedPlayers(Guid achievementID, PlayerAwardedAchievementOrdering? ordering = PlayerAwardedAchievementOrdering.MostRecentlyAwarded, PaginationOptions pagination = null)
        {
            return Request.ExecuteSyncRequest<AwardedPlayersResponse>(
                Config.EndPointPaths.ListAwardedPlayers,
                service,
                ListAwardedPlayersOptions.BuildFormData(achievementID, ordering),
                pagination ?? new PaginationOptions(1, 20)
            );
        }

        /// <summary>
        /// List all players awarded an achievement
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/list-awarded-players" />
        [UsedImplicitly]
        public async Task<AwardedPlayersResponse> ListAwardedPlayersAsync(Guid achievementID, PlayerAwardedAchievementOrdering? ordering = PlayerAwardedAchievementOrdering.MostRecentlyAwarded, PaginationOptions pagination = null)
        {
            return await Request.ExecuteAsyncRequest<AwardedPlayersResponse>(
                Config.EndPointPaths.ListAwardedPlayers,
                service,
                ListAwardedPlayersOptions.BuildFormData(achievementID, ordering),
                pagination ?? new PaginationOptions(1, 20)
            );
        }
    }

    internal static class ListAwardedPlayersOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid achievementID, PlayerAwardedAchievementOrdering? ordering)
        {
            var formData = new Dictionary<string, string>
            {
                { "achievementID", achievementID.ToString() }
            };
            if (ordering.HasValue)
            {
                formData.Add("order", ordering.ToString());
            }
            return formData;
        }
    }
}