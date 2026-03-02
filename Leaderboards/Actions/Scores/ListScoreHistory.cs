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
        /// Lists a Players Score history
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-history" />
        [UsedImplicitly]
        public GetScoreHistoryResponse ListPlayersScoreHistory(ListPlayerScoreHistoryOptions listPlayerScoreHistoryOptions)
        {
            return Request.ExecuteSyncRequest<GetScoreHistoryResponse>(
                Config.EndPointPaths.Scores.ListScoreHistory,
                service,
                listPlayerScoreHistoryOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Lists a Players Score history
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-history" />
        [UsedImplicitly]
        public async Task<GetScoreHistoryResponse> ListPlayersScoreHistoryAsync(ListPlayerScoreHistoryOptions listPlayerScoreHistoryOptions)
        {
            return await Request.ExecuteAsyncRequest<GetScoreHistoryResponse>(
                Config.EndPointPaths.Scores.ListScoreHistory,
                service,
                listPlayerScoreHistoryOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Lists a Scores history
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-history" />
        [UsedImplicitly]
        public GetScoreHistoryResponse ListScoreHistory(ListScoreHistoryOptions listScoreHistoryOptions)
        {
            return Request.ExecuteSyncRequest<GetScoreHistoryResponse>(
                Config.EndPointPaths.Scores.ListScoreHistory,
                service,
                listScoreHistoryOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Lists a Scores history
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-history" />
        [UsedImplicitly]
        public async Task<GetScoreHistoryResponse> ListScoreHistoryAsync(ListScoreHistoryOptions listScoreHistoryOptions)
        {
            return await Request.ExecuteAsyncRequest<GetScoreHistoryResponse>(
                Config.EndPointPaths.Scores.ListScoreHistory,
                service,
                listScoreHistoryOptions.BuildFormData()
            );
        }
    }
}