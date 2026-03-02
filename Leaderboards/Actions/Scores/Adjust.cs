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
        /// Adjust an existing Score for a player.  If Score ID is not specified, Players best score will be updated.
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public PostScoreResponse AdjustPlayersScore(AdjustPlayersScoreOptions adjustPlayersScoreOptions)
        {
            return Request.ExecuteSyncRequest<PostScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustPlayersScoreOptions.BuildFormData(service.LeaderboardID)
            );
        }
        
        /// <summary>
        /// Adjust an existing Score for a player.  If Score ID is not specified, Players best score will be updated.
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public async Task<PostScoreResponse> AdjustPlayersScoreAsync(AdjustPlayersScoreOptions adjustPlayersScoreOptions)
        {
            return await Request.ExecuteAsyncRequest<PostScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustPlayersScoreOptions.BuildFormData(service.LeaderboardID)
            );
        }

        /// <summary>
        /// Adjust an existing Score.
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public PostScoreResponse AdjustScoreByID(AdjustScoreByIDOptions adjustScoreByIDOptions)
        {
            return Request.ExecuteSyncRequest<PostScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustScoreByIDOptions.BuildFormData(service.LeaderboardID)
            );
        }

        /// <summary>
        /// Adjust an existing Score.
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public async Task<PostScoreResponse> AdjustScoreByIDAsync(AdjustScoreByIDOptions adjustScoreByIDOptions)
        {
            return await Request.ExecuteAsyncRequest<PostScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustScoreByIDOptions.BuildFormData(service.LeaderboardID)
            );
        }
    }
}