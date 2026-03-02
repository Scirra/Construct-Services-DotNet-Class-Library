using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
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
        public BaseResponse DeleteTeam(DeleteTeamOptions deleteTeamOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.Delete,
                service,
                deleteTeamOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Delete an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/delete-team" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteTeamAsync(DeleteTeamOptions deleteTeamOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.Delete,
                service,
                deleteTeamOptions.BuildFormData()
            );
        }
    }
}