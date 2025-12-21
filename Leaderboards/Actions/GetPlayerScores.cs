using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    [UsedImplicitly]
    public static GetScoreResponse GetPlayerScores(
        this LeaderboardService service,
        string playerID,
        PaginationOptions paginationOptions)
    {
        const string path = "/getplayerscores.json";
        var formData = new Dictionary<string, string>
        {
            { "playerID", playerID }
        };
        return Request.ExecuteSyncRequest<GetScoreResponse>(
            path,
            service,
            formData,
            paginationOptions
        );
    }
}