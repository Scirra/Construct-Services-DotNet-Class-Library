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
        public BaseResponse AssignPlayerToTeam(string strTeamID,
            string playerID)
        {
            if (string.IsNullOrWhiteSpace(strTeamID))
                return new BaseResponse("No Team ID was provided.", false);
            if (!Guid.TryParse(strTeamID, out var teamID))
                return new BaseResponse("Team ID was not a valid GUID.", false);
            return AssignPlayerToTeam(service, teamID, playerID);
        }

        [UsedImplicitly]
        public BaseResponse AssignPlayerToTeam(Guid teamID, Guid playerID)
        {
            return AssignPlayerToTeam(service, teamID, playerID.ToString());
        }

        [UsedImplicitly]
        public BaseResponse AssignPlayerToTeam(Guid teamID,
            string playerID)
        {
            const string path = "/assignplayertoteam.json";

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