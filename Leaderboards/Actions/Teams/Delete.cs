using System;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{

    extension(LeaderboardService service)
    {
        /// <summary>
        /// Delete an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/delete-team" />
        [UsedImplicitly]
        public BaseResponse DeleteTeam(Guid teamID)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.Delete,
                service,
                DeleteTeamOptions.BuildFormData(teamID)
            );
        }
        
        /// <summary>
        /// Delete an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/delete-team" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteTeamAsync(Guid teamID)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.Delete,
                service,
                DeleteTeamOptions.BuildFormData(teamID)
            );
        }
    }

    private static class DeleteTeamOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid teamID)
        {
            var formData = new Dictionary<string, string>
            {
                { "teamID", teamID.ToString() }
            };
            return formData;
        }
    }
}