using ConstructServices.Leaderboards.Responses;
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
                Config.EndPointPaths.Scores.ListNewest,
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
                Config.EndPointPaths.Scores.ListNewest,
                service,
                formData,
                paginationOptions
            );
        }
    }
}