using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    public static GetScoreResponse GetNewestScores(
        this LeaderboardService service,
        PaginationOptions paginationOptions,
        string countryISOAlpha2 = null,
        RequestPerspective requestPerspective = null)
    {
        const string path = "/getnewestscores.json";
        var formData = new Dictionary<string, string>();
        if (!string.IsNullOrWhiteSpace(countryISOAlpha2))
        {
            formData.Add("country", countryISOAlpha2);
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