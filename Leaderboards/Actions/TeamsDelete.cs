using System;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public BaseResponse DeleteExistingTeam(string strTeamID)
        {
            if (string.IsNullOrWhiteSpace(strTeamID))
                return new BaseResponse("No Team ID was provided.", false);
            if (!Guid.TryParse(strTeamID, out var teamID))
                return new BaseResponse("Team ID was not a valid GUID.", false);
            return service.DeleteExistingTeam(teamID);
        }
        
        [UsedImplicitly]
        public BaseResponse DeleteExistingTeam(Guid teamID)
        {
            const string path = "/deleteteam.json";
            return Request.ExecuteSyncRequest<BaseResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "teamID", teamID.ToString() }
                }
            );
        }
    }
}