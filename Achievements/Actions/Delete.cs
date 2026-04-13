using ConstructServices.Broadcasts.Responses;
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
        /// Delete an existing Achievement
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/delete-achievement" />
        [UsedImplicitly]
        public BaseResponse DeleteAchievement(Guid achievementID)
        {
            return Request.ExecuteSyncRequest<MessageResponse>(
                Config.EndPointPaths.Delete,
                service,
                DeleteAchievementOptions.BuildFormData(achievementID)
            );
        }
        
        /// <summary>
        /// Delete an existing Achievement
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/achievements/api-end-points/achievements/delete-achievement" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteAchievementAsync(Guid achievementID)
        {
            return await Request.ExecuteAsyncRequest<MessageResponse>(
                Config.EndPointPaths.Delete,
                service,
                DeleteAchievementOptions.BuildFormData(achievementID)
            );
        }
    }
    
    private static class DeleteAchievementOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid achievementID)
        {
            var formData = new Dictionary<string, string>
            {
                { "achievementID", achievementID.ToString() }
            };
            return formData;
        }
    }
}