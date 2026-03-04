using System;
using System.Collections.Generic;
using ConstructServices.Common;
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
        public GetTeamResponse GetTeam(Guid teamID)
        {
            return Request.ExecuteSyncRequest<GetTeamResponse>(
                Config.EndPointPaths.Teams.Get,
                service,
                GetTeamOptions.BuildFormData(teamID)
            );
        }
        
        /// <summary>
        /// Get an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/get-team" />
        [UsedImplicitly]
        public async Task<GetTeamResponse> GetTeamAsync(Guid teamID)
        {
            return await Request.ExecuteAsyncRequest<GetTeamResponse>(
                Config.EndPointPaths.Teams.Get,
                service,
                GetTeamOptions.BuildFormData(teamID)
            );
        }
    }

    private static class GetTeamOptions
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