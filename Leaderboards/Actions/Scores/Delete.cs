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
        /// Delete a players Scores
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/delete-scores" />
        [UsedImplicitly]
        public DeleteScoresResponse DeletePlayerScores(DeletePlayerScoresOptions deletePlayerScoresOptions)
        {
            return Request.ExecuteSyncRequest<DeleteScoresResponse>(
                Config.EndPointPaths.Scores.Delete,
                service,
                deletePlayerScoresOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Delete a players Scores
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/delete-scores" />
        [UsedImplicitly]
        public async Task<DeleteScoresResponse> DeletePlayerScoresAsync(DeletePlayerScoresOptions deletePlayerScoresOptions)
        {
            return await Request.ExecuteAsyncRequest<DeleteScoresResponse>(
                Config.EndPointPaths.Scores.Delete,
                service,
                deletePlayerScoresOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Delete an existing Score
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/delete-scores" />
        [UsedImplicitly]
        public DeleteScoresResponse DeleteScore(DeleteScoreOptions deleteScoreOptions)
        {
            return Request.ExecuteSyncRequest<DeleteScoresResponse>(
                Config.EndPointPaths.Scores.Delete,
                service,
                deleteScoreOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Delete an existing Score
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/delete-scores" />
        [UsedImplicitly]
        public async Task<DeleteScoresResponse> DeleteScoreByIDAsync(DeleteScoreOptions deleteScoreOptions)
        {
            return await Request.ExecuteAsyncRequest<DeleteScoresResponse>(
                Config.EndPointPaths.Scores.Delete,
                service,
                deleteScoreOptions.BuildFormData()
            );
        }
    }
}