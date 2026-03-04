using System;
using System.Collections.Generic;
using ConstructServices.Common;
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
        public ScoresResponse ListPlayerScores(
            ListPlayerScoresOptions listPlayerScoresOptions,
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<ScoresResponse>(
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
        public async Task<ScoresResponse> ListPlayerScoresAsync(
            ListPlayerScoresOptions listPlayerScoresOptions,
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<ScoresResponse>(
                Config.EndPointPaths.Scores.ListPlayerScores,
                service,
                listPlayerScoresOptions.BuildFormData(),
                paginationOptions
            );
        }
    }

    
    [UsedImplicitly]
    public sealed class ListPlayerScoresOptions(Guid playerID)
    {
        private Guid PlayerID { get; } = playerID;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "playerID", PlayerID.ToString() }
            };
            return formData;
        }
    }

}