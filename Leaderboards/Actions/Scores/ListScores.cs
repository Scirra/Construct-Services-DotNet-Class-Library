using ConstructServices.Leaderboards.Responses;
using System.Threading.Tasks;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
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
        public GetScoreResponse ListScores(
            ListScoreOptions listScoreOptions, 
            PaginationOptions paginationOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listScoreOptions.BuildFormData();
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<GetScoreResponse>(
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
        public async Task<GetScoreResponse> ListScoresAsync(
            ListScoreOptions listScoreOptions, 
            PaginationOptions paginationOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listScoreOptions.BuildFormData();
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);
            
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<GetScoreResponse>(
                Config.EndPointPaths.Scores.ListScores,
                service,
                formData,
                paginationOptions
            );
        }
    }
}