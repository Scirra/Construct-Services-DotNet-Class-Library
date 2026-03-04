using System;
using System.Collections.Generic;
using ConstructServices.Common;
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
        public DeleteScoresResponse DeletePlayerScores(Guid playerID)
        {
            return Request.ExecuteSyncRequest<DeleteScoresResponse>(
                Config.EndPointPaths.Scores.Delete,
                service,
                DeletePlayerScoreOptions.BuildFormData(playerID)
            );
        }
        
        /// <summary>
        /// Delete a players Scores
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/delete-scores" />
        [UsedImplicitly]
        public async Task<DeleteScoresResponse> DeletePlayerScoresAsync(Guid playerID)
        {
            return await Request.ExecuteAsyncRequest<DeleteScoresResponse>(
                Config.EndPointPaths.Scores.Delete,
                service,
                DeletePlayerScoreOptions.BuildFormData(playerID)
            );
        }

        /// <summary>
        /// Delete an existing Score
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/delete-scores" />
        [UsedImplicitly]
        public DeleteScoresResponse DeleteScore(Guid scoreID)
        {
            return Request.ExecuteSyncRequest<DeleteScoresResponse>(
                Config.EndPointPaths.Scores.Delete,
                service,
                DeleteScoreByIDOptions.BuildFormData(scoreID)
            );
        }
        
        /// <summary>
        /// Delete an existing Score
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/delete-scores" />
        [UsedImplicitly]
        public async Task<DeleteScoresResponse> DeleteScoreByIDAsync(Guid scoreID)
        {
            return await Request.ExecuteAsyncRequest<DeleteScoresResponse>(
                Config.EndPointPaths.Scores.Delete,
                service,
                DeleteScoreByIDOptions.BuildFormData(scoreID)
            );
        }
    }

    
    private static class DeletePlayerScoreOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid playerID)
        {
            var formData = new Dictionary<string, string> { { "playerID", playerID.ToString() } };
            return formData;
        }
    }
    private static class DeleteScoreByIDOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid scoreID)
        {
            var formData = new Dictionary<string, string> { { "scoreID", scoreID.ToString() } };
            return formData;
        }
    }

}