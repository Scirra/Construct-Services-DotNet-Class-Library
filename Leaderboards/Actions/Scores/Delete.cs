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

    
    [UsedImplicitly]
    public abstract class DeleteScoreBase(Guid? scoreID, Guid? playerID)
    {
        private Guid? ScoreID { get; } = scoreID;
        private Guid? PlayerID { get; } = playerID;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (ScoreID.HasValue)
            {
                formData.Add("scoreID", ScoreID.Value.ToString());
            }
            if (PlayerID.HasValue)
            {
                formData.Add("playerID", PlayerID.Value.ToString());
            }
            return formData;
        }
    }

    [UsedImplicitly]
    public sealed class DeleteScoreOptions(Guid scoreID) : DeleteScoreBase(scoreID, null);

    [UsedImplicitly]
    public sealed class DeletePlayerScoresOptions(Guid playerID) : DeleteScoreBase(null, playerID);

}