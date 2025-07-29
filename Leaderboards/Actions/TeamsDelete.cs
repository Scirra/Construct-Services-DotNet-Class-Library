using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    [UsedImplicitly]
    public static BaseResponse DeleteExistingTeam(
        this LeaderboardService service,
        string strTeamID)
    {
        if (string.IsNullOrWhiteSpace(strTeamID))
            return new BaseResponse("No Team ID was provided.", false);
        if (!Guid.TryParse(strTeamID, out var teamID))
            return new BaseResponse("Team ID was not a valid GUID.", false);
        return DeleteExistingTeam(service, teamID);
    }
    public static BaseResponse DeleteExistingTeam(
        this LeaderboardService service,
        Guid teamID)
    {
        const string path = "/deleteteam.json";
        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "teamID", teamID.ToString() }
            }
        )).Result;
    }
}