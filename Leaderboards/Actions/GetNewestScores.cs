using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    private const string GetNewestScoresAPIPath = "/getnewestscores.json";
    
    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public GetScoreResponse GetNewestScores(PaginationOptions paginationOptions,
            string countryISOAlpha2 = null,
            RequestPerspective requestPerspective = null)
        {
            var formData = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(countryISOAlpha2))
            {
                formData.Add("country", countryISOAlpha2);
            }
        
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<GetScoreResponse>(
                GetNewestScoresAPIPath,
                service,
                formData,
                paginationOptions
            );
        }

        [UsedImplicitly]
        public async Task<GetScoreResponse> GetNewestScoresAsync(PaginationOptions paginationOptions,
            string countryISOAlpha2 = null,
            RequestPerspective requestPerspective = null)
        {
            var formData = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(countryISOAlpha2))
            {
                formData.Add("country", countryISOAlpha2);
            }
        
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<GetScoreResponse>(
                GetNewestScoresAPIPath,
                service,
                formData,
                paginationOptions
            );
        }
    }
}