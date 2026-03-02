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
        /// Delete an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/delete-team" />
        [UsedImplicitly]
        public BaseResponse DeleteTeam(DeleteTeamOptions deleteTeamOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.Delete,
                service,
                deleteTeamOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Delete an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/delete-team" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteTeamAsync(DeleteTeamOptions deleteTeamOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.Delete,
                service,
                deleteTeamOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class DeleteTeamOptions(Guid teamID)
    {
        private Guid TeamID { get; } = teamID;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "teamID", TeamID.ToString() }
            };
            return formData;
        }
    }
}