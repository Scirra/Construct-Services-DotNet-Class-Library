using System.Collections.Generic;
using ConstructServices.Common;
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
        public TeamResponse CreateTeam(string teamName)
        {
            return Request.ExecuteSyncRequest<TeamResponse>(
                Config.EndPointPaths.Teams.Create,
                service,
                CreateTeamOptions.BuildFormData(teamName)
            );
        }

        /// <summary>
        /// Create a new Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/create-team" />
        [UsedImplicitly]
        public async Task<TeamResponse> CreateTeamAsync(string teamName)
        {
            return await Request.ExecuteAsyncRequest<TeamResponse>(
                Config.EndPointPaths.Teams.Create,
                service,
                CreateTeamOptions.BuildFormData(teamName)
            );
        }
    }

    private static class CreateTeamOptions
    {
        internal static Dictionary<string, string> BuildFormData(string teamName)
        {
            var formData = new Dictionary<string, string>
            {
                { "teamName", teamName }
            };
            return formData;
        }
    }
}