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

    [UsedImplicitly]
    public sealed class CreateTeamOptions(string name)
    {
        private string Name { get; } = name;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "teamName", Name }
            };
            return formData;
        }
    }
}