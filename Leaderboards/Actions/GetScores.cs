using ConstructServices.Leaderboards.Enums;
using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    private const string GetScoresAPIPath = "/getscores.json";
    
    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public GetScoreResponse GetScores(PaginationOptions paginationOptions,
            string countryISOAlpha2 = null,
            ScoreRange? range = null,
            int? rangeOffset = null,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
        {
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

            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<GetScoreResponse>(
                GetScoresAPIPath,
                service,
                formData,
                paginationOptions
            );
        }

        [UsedImplicitly]
        public async Task<GetScoreResponse> GetScoresAsync(PaginationOptions paginationOptions,
            string countryISOAlpha2 = null,
            ScoreRange? range = null,
            int? rangeOffset = null,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
        {
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

            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<GetScoreResponse>(
                GetScoresAPIPath,
                service,
                formData,
                paginationOptions
            );
        }
    }
}