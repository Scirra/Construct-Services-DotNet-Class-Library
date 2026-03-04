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
        public BaseResponse AssignPlayerToTeam(Guid teamID, AssignPlayerOptions assignPlayerOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.AssignPlayer,
                service,
                assignPlayerOptions.BuildFormData(teamID)
            );
        }

        /// <summary>
        /// Assign a player to an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/assign-player" />
        [UsedImplicitly]
        public async Task<BaseResponse> AssignPlayerToTeamAsync(Guid teamID, AssignPlayerOptions assignPlayerOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.AssignPlayer,
                service,
                assignPlayerOptions.BuildFormData(teamID)
            );
        }
    }

    [UsedImplicitly]
    public sealed class AssignPlayerOptions( Guid playerID)
    {
        private Guid PlayerID { get; } = playerID;

        internal Dictionary<string, string> BuildFormData(Guid teamID)
        {
            var formData = new Dictionary<string, string>
            {
                { "teamID", teamID.ToString() },
                { "playerID", PlayerID.ToString() }
            };
            return formData;
        }
    }
}