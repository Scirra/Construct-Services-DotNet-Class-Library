using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    extension(LeaderboardServiceBase service)
    {
        /// <summary>
        /// Get a Score by ID
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score" />
        [UsedImplicitly]
        public GetScoreResponse GetScore(Guid scoreID)
        {
            return Request.ExecuteSyncRequest<GetScoreResponse>(
                Config.EndPointPaths.Scores.Get,
                service,
                GetScoreOptions.BuildFormData(scoreID)
            );
        }
        
        /// <summary>
        /// Delete a players Scores
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score" />
        [UsedImplicitly]
        public async Task<GetScoreResponse> GetScoreAsync(Guid scoreID)
        {
            return await Request.ExecuteAsyncRequest<GetScoreResponse>(
                Config.EndPointPaths.Scores.Get,
                service,
                GetScoreOptions.BuildFormData(scoreID)
            );
        }
    }
    
    private static class GetScoreOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid scoreID)
        {
            var formData = new Dictionary<string, string> { { "scoreID", scoreID.ToString() } };
            return formData;
        }
    }
}
