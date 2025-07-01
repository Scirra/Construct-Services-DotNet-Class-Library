using System;
using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions
{
    public static partial class Teams
    {
        public static BaseResponse RemovePlayerFromTeam(
            this LeaderboardService service,
            string strTeamID,
            string playerID)
        {
            if (string.IsNullOrWhiteSpace(strTeamID))
                return new BaseResponse("No Team ID was provided.", false);
            if (!Guid.TryParse(strTeamID, out var teamID))
                return new BaseResponse("Score Team was not a valid GUID.", false);
            return RemovePlayerFromTeam(service, teamID, playerID);
        }
        public static BaseResponse RemovePlayerFromTeam(
            this LeaderboardService service,
            Guid teamID,
            string playerID)
        {
            const string path = "/removeplayerfromteam.json";

            return Task.Run(() => Request.ExecuteLeaderboardRequest<BaseResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "teamID", teamID.ToString() },
                    { "playerID", playerID }
                }
            )).Result;
        }
    }
}
