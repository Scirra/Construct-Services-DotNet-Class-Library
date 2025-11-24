using ConstructServices.Leaderboards.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public GetScoreNeighboursResponse GetScoreNeighbours(string playerID,
            int range = 5,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
            => Execute(service, playerID, null, range, compareRanks, requestPerspective);

        [UsedImplicitly]
        public GetScoreNeighboursResponse GetScoreNeighbours(Guid scoreID,
            int range = 5,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
            => Execute(service, null, scoreID, range, compareRanks, requestPerspective);
    }

    private static GetScoreNeighboursResponse Execute(
        LeaderboardService service,
        string playerID,
        Guid? scoreID,
        int range,
        int? compareRanks = null,
        RequestPerspective requestPerspective = null)
    {
        const string path = "/getscoreneighbours.json";
        var formData = new Dictionary<string, string>
        {
            { "range", range.ToString() }
        };
        if (!string.IsNullOrWhiteSpace(playerID))
        {
            formData.Add("playerID", playerID);
        }
        if (scoreID.HasValue)
        {
            formData.Add("scoreID", scoreID.Value.ToString());
        }
        if (compareRanks.HasValue)
        {
            formData.Add("compareRanks", compareRanks.Value.ToString());
        }

        LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

        return Task.Run(() => Request.ExecuteRequest<GetScoreNeighboursResponse>(
            path,
            service,
            formData
        )).Result;
    }
}