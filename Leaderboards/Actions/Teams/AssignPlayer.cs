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

    [UsedImplicitly]
    public sealed class AssignPlayerOptions(Guid teamID, Guid playerID)
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