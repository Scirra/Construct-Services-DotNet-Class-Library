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
        /// Create a new Score on a Leaderboard
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/post-score" />
        [UsedImplicitly]
        public PostScoreResponse CreateScore(
            CreateScoreOptions createScoreOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = createScoreOptions.BuildFormData(service.LeaderboardID);

            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<PostScoreResponse>(
                Config.EndPointPaths.Scores.Create,
                service,
                formData
            );
        }

        /// <summary>
        /// Create a new Score on a Leaderboard
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/post-score" />
        [UsedImplicitly]
        public async Task<PostScoreResponse> CreateScoreAsync(
            CreateScoreOptions createScoreOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = createScoreOptions.BuildFormData(service.LeaderboardID);

            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<PostScoreResponse>(
                Config.EndPointPaths.Scores.Create,
                service,
                formData
            );
        }
    }
}