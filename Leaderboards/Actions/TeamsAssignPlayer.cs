﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    [UsedImplicitly]
    public static BaseResponse AssignPlayerToTeam(
        this LeaderboardService service,
        string strTeamID,
        string playerID)
    {
        if (string.IsNullOrWhiteSpace(strTeamID))
            return new BaseResponse("No Team ID was provided.", false);
        if (!Guid.TryParse(strTeamID, out var teamID))
            return new BaseResponse("Team ID was not a valid GUID.", false);
        return AssignPlayerToTeam(service, teamID, playerID);
    }
    public static BaseResponse AssignPlayerToTeam(
        this LeaderboardService service,
        Guid teamID,
        string playerID)
    {
        const string path = "/assignplayertoteam.json";

        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
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