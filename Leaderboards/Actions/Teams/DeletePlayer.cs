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

    [UsedImplicitly]
    public sealed class DeleteTeamPlayerOptions(Guid teamID, Guid playerID)
    {
        private Guid TeamID { get; } = teamID;
        private Guid PlayerID { get; } = playerID;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "teamID", TeamID.ToString() },
                { "playerID", PlayerID.ToString() }
            };
            return formData;
        }
    }
}