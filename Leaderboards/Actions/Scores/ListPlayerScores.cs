using System;
using System.Collections.Generic;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores{
    
    extension(LeaderboardServiceBase service)
    {
        /// <summary>
        /// List a Players Scores
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-player-scores" />
        [UsedImplicitly]
        public ScoresResponse ListPlayerScores(
            Guid playerID,
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<ScoresResponse>(
                Config.EndPointPaths.Scores.ListPlayerScores,
                service,
                ListPlayerScoresOptions.BuildFormData(playerID),
                paginationOptions
            );
        }

        /// <summary>
        /// List a Players Scores
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-player-scores" />
        [UsedImplicitly]
        public async Task<ScoresResponse> ListPlayerScoresAsync(
            Guid playerID,
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<ScoresResponse>(
                Config.EndPointPaths.Scores.ListPlayerScores,
                service,
                ListPlayerScoresOptions.BuildFormData(playerID),
                paginationOptions
            );
        }
    }

    private static class ListPlayerScoresOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid playerID)
        {
            var formData = new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() }
            };
            return formData;
        }
    }

}