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
        /// Assign a player to an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/assign-player" />
        [UsedImplicitly]
        public BaseResponse AssignPlayerToTeam(Guid teamID, Guid playerID)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.AssignPlayer,
                service,
                AssignPlayerOptions.BuildFormData(teamID, playerID)
            );
        }

        /// <summary>
        /// Assign a player to an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/assign-player" />
        [UsedImplicitly]
        public async Task<BaseResponse> AssignPlayerToTeamAsync(Guid teamID, Guid playerID)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.AssignPlayer,
                service,
                AssignPlayerOptions.BuildFormData(teamID, playerID)
            );
        }
    }

    private static class AssignPlayerOptions
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