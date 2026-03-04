using System.Collections.Generic;
using ConstructServices.Leaderboards.Responses;
using System.Threading.Tasks;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Enums;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    extension(LeaderboardService service)
    {
        /// <summary>
        /// List all Scores
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-scores" />
        [UsedImplicitly]
        public ScoresResponse ListScores(
            ListScoreOptions listScoreOptions, 
            PaginationOptions paginationOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listScoreOptions.BuildFormData();
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<ScoresResponse>(
                Config.EndPointPaths.Scores.ListScores,
                service,
                formData,
                paginationOptions
            );
        }

        /// <summary>
        /// List all Scores
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-scores" />
        [UsedImplicitly]
        public async Task<ScoresResponse> ListScoresAsync(
            ListScoreOptions listScoreOptions, 
            PaginationOptions paginationOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listScoreOptions.BuildFormData();
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);
            
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<ScoresResponse>(
                Config.EndPointPaths.Scores.ListScores,
                service,
                formData,
                paginationOptions
            );
        }
    }

    
    [UsedImplicitly]
    public sealed class ListScoreOptions()
    {
        [UsedImplicitly]
        public string CountryISO { get; set; }

        [UsedImplicitly]
        public short? CompareRanks { get; set; }

        [UsedImplicitly]
        public ScoreRange? Range { get; set; }

        [UsedImplicitly]
        public short? RangeOffset { get; set; }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(CountryISO))
            {
                formData.Add("country", CountryISO);
            }
            if (CompareRanks.HasValue)
            {
                formData.Add("compareRanks", CompareRanks.Value.ToString());
            }
            if (Range.HasValue)
            {
                formData.Add("range", Range.Value.ToString());
            }
            if (RangeOffset.HasValue)
            {
                formData.Add("rangeOffset", RangeOffset.Value.ToString());
            }
            return formData;
        }
    }

}