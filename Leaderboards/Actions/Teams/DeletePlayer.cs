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
        /// Delete a player from a Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/remove-player" />
        [UsedImplicitly]
        public BaseResponse DeletePlayerFromTeam(DeleteTeamPlayerOptions deleteTeamPlayerOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.DeletePlayer,
                service,
                deleteTeamPlayerOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Delete a player from a Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/remove-player" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeletePlayerFromTeamAsync(DeleteTeamPlayerOptions deleteTeamPlayerOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.DeletePlayer,
                service,
                deleteTeamPlayerOptions.BuildFormData()
            );
        }
    }
}