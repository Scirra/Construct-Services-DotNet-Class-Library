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
        public BaseResponse RenameTeam(string strTeamID,
            string teamName)
        {
            if (string.IsNullOrWhiteSpace(strTeamID))
                return new BaseResponse("No Team ID was provided.", false);
            if (!Guid.TryParse(strTeamID, out var teamID))
                return new BaseResponse("Team ID was not a valid GUID.", false);
            return service.RenameTeam(teamID, teamName);
        }
        
        [UsedImplicitly] 
        public BaseResponse RenameTeam(Guid teamID,
            string teamName)
        {
            const string path = "/renameteam.json";

            return Request.ExecuteSyncRequest<BaseResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "teamID", teamID.ToString() },
                    { "teamName", teamName }
                }
            );
        }
    }
}