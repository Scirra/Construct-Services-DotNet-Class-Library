using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using ConstructServices.Leaderboards.Responses;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    extension(LeaderboardService service)
    {
        /// <summary>
        /// Get an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/get-team" />
        [UsedImplicitly]
        public GetTeamResponse GetTeam(GetTeamOptions getTeamOptions)
        {
            return Request.ExecuteSyncRequest<GetTeamResponse>(
                Config.EndPointPaths.Teams.Get,
                service,
                getTeamOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Get an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/get-team" />
        [UsedImplicitly]
        public async Task<GetTeamResponse> GetTeamAsync(GetTeamOptions getTeamOptions)
        {
            return await Request.ExecuteAsyncRequest<GetTeamResponse>(
                Config.EndPointPaths.Teams.Get,
                service,
                getTeamOptions.BuildFormData()
            );
        }
    }
}