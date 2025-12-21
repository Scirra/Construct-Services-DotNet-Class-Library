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
        public BaseResponse RemovePlayerFromTeam(string strTeamID,
            string playerID)
        {
            if (string.IsNullOrWhiteSpace(strTeamID))
                return new BaseResponse("No Team ID was provided.", false);
            if (!Guid.TryParse(strTeamID, out var teamID))
                return new BaseResponse("Score Team was not a valid GUID.", false);
            return service.RemovePlayerFromTeam(teamID, playerID);
        }
        
        [UsedImplicitly]
        public BaseResponse RemovePlayerFromTeam(Guid teamID,
            string playerID)
        {
            const string path = "/removeplayerfromteam.json";

            return Request.ExecuteSyncRequest<BaseResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "teamID", teamID.ToString() },
                    { "playerID", playerID }
                }
            );
        }
    }
}