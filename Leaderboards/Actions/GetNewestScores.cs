using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    [UsedImplicitly]
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
        
        LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

        return Task.Run(() => Request.ExecuteRequest<GetScoreResponse>(
            path,
            service,
            formData,
            paginationOptions
        )).Result;
    }
}