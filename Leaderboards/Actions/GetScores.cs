using ConstructServices.Leaderboards.Enums;
using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    public static GetScoreResponse GetScores(
        this LeaderboardService service,
        PaginationOptions paginationOptions,
        string countryISOAlpha2 = null,
        ScoreRange? range = null,
        int? rangeOffset = null,
        int? compareRanks = null,
        RequestPerspective requestPerspective = null)
    {
        const string path = "/getscores.json";
        var formData = new Dictionary<string, string>();
        if (!string.IsNullOrWhiteSpace(countryISOAlpha2))
        {
            formData.Add("country", countryISOAlpha2);
        }
        if (range != null)
        {
            formData.Add("range", range.Value.ToString());
        }
        if (rangeOffset.HasValue)
        {
            formData.Add("rangeOffset", rangeOffset.Value.ToString());
        }
        if (compareRanks.HasValue)
        {
            formData.Add("compareRanks", compareRanks.Value.ToString());
        }
        return Task.Run(() => Request.ExecuteLeaderboardRequest<GetScoreResponse>(
            path,
            service,
            formData,
            requestPerspective,
            paginationOptions
        )).Result;
    }
}