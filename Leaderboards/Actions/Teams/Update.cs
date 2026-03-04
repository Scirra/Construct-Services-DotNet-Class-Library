using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    extension(LeaderboardService service)
    {
        /// <summary>
        /// Rename an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/rename-team" />
        [UsedImplicitly]
        public BaseResponse UpdateTeam(Guid teamID, UpdateTeamOptions updateTeamOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.Update,
                service,
                updateTeamOptions.BuildFormData(teamID)
            );
        }
        
        /// <summary>
        /// Rename an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/rename-team" />
        [UsedImplicitly]
        public async Task<BaseResponse> UpdateTeamAsync(Guid teamID, UpdateTeamOptions updateTeamOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.Update,
                service,
                updateTeamOptions.BuildFormData(teamID)
            );
        }
    }

    [UsedImplicitly]
    public sealed class UpdateTeamOptions()
    {
        [UsedImplicitly]
        public string Name { get; set; }

        internal Dictionary<string, string> BuildFormData(Guid teamID)
        {
            var formData = new Dictionary<string, string>
            {
                { "teamID", teamID.ToString() },
                { "teamName", Name }
            };
            return formData;
        }
    }
}