using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.Leaderboards.Objects;

namespace ConstructServices.Leaderboards.Actions;
public static partial class Teams
{
    extension(LeaderboardService service)
    {
        /// <summary>
        /// Assign a player to an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/assign-player" />
        [UsedImplicitly]
        public BaseResponse AssignPlayerToTeam(AssignPlayerOptions assignPlayerOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.AssignPlayer,
                service,
                assignPlayerOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Assign a player to an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/assign-player" />
        [UsedImplicitly]
        public async Task<BaseResponse> AssignPlayerToTeamAsync(AssignPlayerOptions assignPlayerOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.AssignPlayer,
                service,
                assignPlayerOptions.BuildFormData()
            );
        }
    }
}