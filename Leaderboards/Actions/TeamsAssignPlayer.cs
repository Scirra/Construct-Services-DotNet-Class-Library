using System;
using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions
{
    public static partial class Teams
    {
        public static BaseResponse AssignPlayerToTeam(
            this LeaderboardService service,
            string strTeamID,
            string playerIdentifier)
        {
            if (string.IsNullOrWhiteSpace(strTeamID))
                return new BaseResponse("No Team ID was provided.", false);
            if (!Guid.TryParse(strTeamID, out var teamID))
                return new BaseResponse("Team ID was not a valid GUID.", false);
            return AssignPlayerToTeam(service, teamID, playerIdentifier);
        }
        public static BaseResponse AssignPlayerToTeam(
            this LeaderboardService service,
            Guid teamID,
            string playerIdentifier)
        {
            const string path = "/assignplayertoteam.json";

            return Task.Run(() => Request.ExecuteLeaderboardRequest<BaseResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "teamID", teamID.ToString() },
                    { "playerID", playerIdentifier }
                }
            )).Result;
        }
    }
}
