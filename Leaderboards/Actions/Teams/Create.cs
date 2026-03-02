using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    extension(LeaderboardService service)
    {
        /// <summary>
        /// Create a new Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/create-team" />
        [UsedImplicitly]
        public CreateTeamResponse CreateTeam(CreateTeamOptions createTeamOptions)
        {
            return Request.ExecuteSyncRequest<CreateTeamResponse>(
                Config.EndPointPaths.Teams.Create,
                service,
                createTeamOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Create a new Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/create-team" />
        [UsedImplicitly]
        public async Task<CreateTeamResponse> CreateTeamAsync(CreateTeamOptions createTeamOptions)
        {
            return await Request.ExecuteAsyncRequest<CreateTeamResponse>(
                Config.EndPointPaths.Teams.Create,
                service,
                createTeamOptions.BuildFormData()
            );
        }
    }
}