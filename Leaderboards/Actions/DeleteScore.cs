﻿using System;
using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    [UsedImplicitly]
    public static ShadowBanResponse DeleteAllPlayerIDScores(
        this LeaderboardService service,
        string playerID)
    {
        const string path = "/deletescores.json";
        return Task.Run(() => Request.ExecuteRequest<ShadowBanResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "playerID", playerID }
            }
        )).Result;
    }
        
    [UsedImplicitly]
    public static ShadowBanResponse DeleteScoreByID(
        this LeaderboardService service,
        string strScoreID)
    {
        if (string.IsNullOrWhiteSpace(strScoreID))
            return new ShadowBanResponse("No Score ID was provided.", false);
        if (!Guid.TryParse(strScoreID, out var scoreID))
            return new ShadowBanResponse("Score ID was not a valid GUID.", false);
        return DeleteScoreByID(service, scoreID);
    }
    public static ShadowBanResponse DeleteScoreByID(
        this LeaderboardService service,
        Guid scoreID)
    {
        const string path = "/deletescores.json";

        return Task.Run(() => Request.ExecuteRequest<ShadowBanResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "scoreID", scoreID.ToString() }
            }
        )).Result;
    }
}