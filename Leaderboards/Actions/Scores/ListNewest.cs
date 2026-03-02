using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    
    extension(LeaderboardService service)
    {
        /// <summary>
        /// List the newest Scores in a Leaderboard
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-newest-scores" />
        [UsedImplicitly]
        public GetScoreResponse GetNewestScores(
            ListNewestScoresOptions listNewestScoresOptions,
            PaginationOptions paginationOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listNewestScoresOptions.BuildFormData();

            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<GetScoreResponse>(
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
        public async Task<GetScoreResponse> GetNewestScoresAsync(
            ListNewestScoresOptions listNewestScoresOptions,
            PaginationOptions paginationOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listNewestScoresOptions.BuildFormData();

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