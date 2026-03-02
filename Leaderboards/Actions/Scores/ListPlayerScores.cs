using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores{
    
    extension(LeaderboardService service)
    {
        /// <summary>
        /// List a Players Scores
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-player-scores" />
        [UsedImplicitly]
        public GetScoreResponse ListPlayerScores(
            ListPlayerScoresOptions listPlayerScoresOptions,
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<GetScoreResponse>(
                Config.EndPointPaths.Scores.ListPlayerScores,
                service,
                listPlayerScoresOptions.BuildFormData(),
                paginationOptions
            );
        }

        /// <summary>
        /// List a Players Scores
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-player-scores" />
        [UsedImplicitly]
        public async Task<GetScoreResponse> ListPlayerScoresAsync(
            ListPlayerScoresOptions listPlayerScoresOptions,
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<GetScoreResponse>(
                Config.EndPointPaths.Scores.ListPlayerScores,
                service,
                listPlayerScoresOptions.BuildFormData(),
                paginationOptions
            );
        }
    }
}