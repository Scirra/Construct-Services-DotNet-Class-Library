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
        /// Delete a player from a Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/remove-player" />
        [UsedImplicitly]
        public BaseResponse DeletePlayerFromTeam(Guid teamID, Guid playerID)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.DeletePlayer,
                service,
                DeleteTeamPlayerOptions.BuildFormData(teamID, playerID)
            );
        }
        
        /// <summary>
        /// Delete a player from a Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/remove-player" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeletePlayerFromTeamAsync(Guid teamID, Guid playerID)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.DeletePlayer,
                service,
                DeleteTeamPlayerOptions.BuildFormData(teamID, playerID)
            );
        }
    }

    private static class DeleteTeamPlayerOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid teamID, Guid playerID)
        {
            var formData = new Dictionary<string, string>
            {
                { "teamID", teamID.ToString() },
                { "playerID", playerID.ToString() }
            };
            return formData;
        }
    }
}