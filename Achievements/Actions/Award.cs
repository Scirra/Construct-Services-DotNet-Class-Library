using ConstructServices.Achievements.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Achievements;

public static partial class Actions
{
    extension(AchievementService service)
    {
        /// <summary>
        /// Award or progress an Achievement
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/award-achievement" />
        [UsedImplicitly]
        public PlayerAchievementsResponse AwardAchievement(Guid playerID, AwardAchievementOptions awardAchievementOptions)
        {
            return Request.ExecuteSyncRequest<PlayerAchievementsResponse>(
                Config.EndPointPaths.Award,
                service,
                awardAchievementOptions.BuildFormData(playerID)
            );
        }

        /// <summary>
        /// Award or progress an Achievement
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/award-achievement" />
        [UsedImplicitly]
        public async Task<PlayerAchievementsResponse> AwardAchievementAsync(Guid playerID, AwardAchievementOptions awardAchievementOptions)
        {
            return await Request.ExecuteAsyncRequest<PlayerAchievementsResponse>(
                Config.EndPointPaths.Award,
                service,
                awardAchievementOptions.BuildFormData(playerID)
            );
        }
    }

    extension(PlayerAchievementService service)
    {
        /// <summary>
        /// Award or progress an Achievement
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/award-achievement" />
        [UsedImplicitly]
        public PlayerAchievementsResponse AwardAchievement(AwardAchievementOptions awardAchievementOptions)
        {
            return Request.ExecuteSyncRequest<PlayerAchievementsResponse>(
                Config.EndPointPaths.Award,
                service,
                awardAchievementOptions.BuildFormData(null)
            );
        }

        /// <summary>
        /// Award or progress an Achievement
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/award-achievement" />
        [UsedImplicitly]
        public async Task<PlayerAchievementsResponse> AwardAchievementAsync(AwardAchievementOptions awardAchievementOptions)
        {
            return await Request.ExecuteAsyncRequest<PlayerAchievementsResponse>(
                Config.EndPointPaths.Award,
                service,
                awardAchievementOptions.BuildFormData(null)
            );
        }
    }

    [UsedImplicitly]
    public sealed class AwardAchievementOptions
    {
        [UsedImplicitly]
        public Guid AchievementID { private get; set; }

        [UsedImplicitly]
        public int Value { private get; set; }

        internal Dictionary<string, string> BuildFormData(Guid? playerID)
        {
            var r = new Dictionary<string, string>
            {
                { "achievementID", AchievementID.ToString() },
                { "value", Value.ToString() }
            };
            if (playerID.HasValue)
            {
                r.Add("playerID", playerID.Value.ToString());
            }
            return r;
        }
    }
}