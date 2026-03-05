using System.Collections.Generic;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    extension(LeaderboardServiceBase service)
    {
        /// <summary>
        /// List the newest Scores in a Leaderboard
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-newest-scores" />
        [UsedImplicitly]
        public ScoresResponse ListNewestScores(
            ListNewestScoresOptions listNewestScoresOptions,
            PaginationOptions paginationOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listNewestScoresOptions.BuildFormData();

            LeaderboardServiceBase.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<ScoresResponse>(
                Config.EndPointPaths.Scores.ListNewest,
                service,
                formData,
                paginationOptions
            );
        }

        /// <summary>
        /// List the newest Scores in a Leaderboard
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-newest-scores" />
        [UsedImplicitly]
        public async Task<ScoresResponse> ListNewestScoresAsync(
            ListNewestScoresOptions listNewestScoresOptions,
            PaginationOptions paginationOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listNewestScoresOptions.BuildFormData();

            LeaderboardServiceBase.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<ScoresResponse>(
                Config.EndPointPaths.Scores.ListNewest,
                service,
                formData,
                paginationOptions
            );
        }
    }
    

    [UsedImplicitly]
    public sealed class ListNewestScoresOptions(string countryISO = null)
    {
        private string CountryISO { get; } = countryISO;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(CountryISO))
            {
                formData.Add("country", CountryISO);
            }
            return formData;
        }
    }
}