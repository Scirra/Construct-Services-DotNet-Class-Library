using ConstructServices.Leaderboards.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    public static PostScoreResponse AdjustExistingScore(
        this LeaderboardService service,
        Guid scoreID,
        long adjustment,
        short optValue1 = 0,
        short optValue2 = 0,
        short optValue3 = 0)
    {
        return DoAdjustExistingScore(service, null, scoreID, adjustment, optValue1, optValue2, optValue3);
    }
    public static PostScoreResponse AdjustExistingScore(
        this LeaderboardService service,
        string sessionKey,
        Guid scoreID,
        long adjustment,
        short optValue1 = 0,
        short optValue2 = 0,
        short optValue3 = 0)
    {
        return DoAdjustExistingScore(service, sessionKey, scoreID, adjustment, optValue1, optValue2, optValue3);
    }
    private static PostScoreResponse DoAdjustExistingScore(
        this LeaderboardService service,
        string sessionKey,
        Guid scoreID,
        long adjustment,
        short optValue1 = 0,
        short optValue2 = 0,
        short optValue3 = 0)
    {
        const string path = "/adjustscore.json";

        var timestamp = ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();
        var hash = Common.Functions.GetSHA256Hash(service.LeaderboardID + "." + adjustment + "." + scoreID + "." + timestamp + ".");

        var formData = new Dictionary<string, string>
        {
            { "hash", hash },
            { "adjustment", adjustment.ToString() },
            { "timestamp", timestamp.ToString() },
            { "scoreID", scoreID.ToString() },
            { "sessionKey", sessionKey }
        };
        if (optValue1 != 0)
        {
            formData.Add("opt1", optValue1.ToString());
        }
        if (optValue2 != 0)
        {
            formData.Add("opt2", optValue2.ToString());
        }
        if (optValue3 != 0)
        {
            formData.Add("opt3", optValue3.ToString());
        }
        return Task.Run(() => Request.ExecuteLeaderboardRequest<PostScoreResponse>(
            path,
            service,
            formData
        )).Result;
    }
}