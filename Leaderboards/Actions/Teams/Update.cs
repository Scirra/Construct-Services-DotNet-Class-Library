using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
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
        public BaseResponse UpdateTeam(UpdateTeamOptions updateTeamOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.Rename,
                service,
                updateTeamOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Rename an existing Team
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/teams/rename-team" />
        [UsedImplicitly]
        public async Task<BaseResponse> UpdateTeamAsync(UpdateTeamOptions updateTeamOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Teams.Rename,
                service,
                updateTeamOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class UpdateTeamOptions(Guid teamID, string name)
    {
        private Guid TeamID { get; } = teamID;
        private string Name { get; } = name;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "teamID", TeamID.ToString() },
                { "teamName", Name }
            };
            return formData;
        }
    }
}