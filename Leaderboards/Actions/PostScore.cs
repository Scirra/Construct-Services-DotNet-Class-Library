﻿using ConstructServices.Leaderboards.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    [UsedImplicitly]
    public static PostScoreResponse PostNewScore(
        this LeaderboardService service,
        long score,
        string strPlayerID,
        short? optValue1,
        short? optValue2,
        short? optValue3,
        RequestPerspective requestPerspective = null)
    {
        return DoPostNewScore(service, null, score, strPlayerID, optValue1, optValue2, optValue3,
            requestPerspective);
    }
    [UsedImplicitly]
    public static PostScoreResponse PostNewScore(
        this LeaderboardService service,
        string sessionKey,
        long score,
        string strPlayerID,
        short? optValue1,
        short? optValue2,
        short? optValue3,
        RequestPerspective requestPerspective = null)
    {
        return DoPostNewScore(service, sessionKey, score, strPlayerID, optValue1, optValue2, optValue3,
            requestPerspective);
    }

    private static PostScoreResponse DoPostNewScore(
        this LeaderboardService service,
        string sessionKey,
        long score,
        string strPlayerID,
        short? optValue1,
        short? optValue2,
        short? optValue3,
        RequestPerspective requestPerspective = null)
    {
        const string path = "/postscore.json";

        strPlayerID = (strPlayerID ?? string.Empty).Trim();

        var timestamp = ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();
        var hash = Functions.GetSHA256Hash(service.LeaderboardID + "." + score + "." + timestamp + "." + strPlayerID);

        var formData = new Dictionary<string, string>
        {
            { "hash", hash },
            { "score", score.ToString() },
            { "timestamp", timestamp.ToString() }
        };
        if (!string.IsNullOrWhiteSpace(sessionKey))
        {
            formData.Add("sessionKey", sessionKey);
        }
        if (!string.IsNullOrWhiteSpace(strPlayerID))
        {
            formData.Add("playerID", strPlayerID);
        }
        if (optValue1.HasValue)
        {
            formData.Add("opt1", optValue1.Value.ToString());
        }
        if (optValue2.HasValue)
        {
            formData.Add("opt2", optValue2.Value.ToString());
        }
        if (optValue3.HasValue)
        {
            formData.Add("opt3", optValue3.Value.ToString());
        }

        service.AddRequestPerspectiveFormData(requestPerspective, formData);

        return Task.Run(() => Request.ExecuteRequest<PostScoreResponse>(
            path,
            service,
            formData
        )).Result;
    }
}