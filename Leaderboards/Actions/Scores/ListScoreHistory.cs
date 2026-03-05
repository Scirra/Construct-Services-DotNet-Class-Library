using System;
using System.Collections.Generic;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    extension(LeaderboardServiceBase service)
    {
        /// <summary>
        /// Lists a Players Score history
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-history" />
        [UsedImplicitly]
        public ListScoreHistoryResponse ListPlayersScoreHistory(Guid playerID)
        {
            return Request.ExecuteSyncRequest<ListScoreHistoryResponse>(
                Config.EndPointPaths.Scores.ListScoreHistory,
                service,
                ListScoreHistoryBase.BuildFormData(null, playerID)
            );
        }

        /// <summary>
        /// Lists a Players Score history
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-history" />
        [UsedImplicitly]
        public async Task<ListScoreHistoryResponse> ListPlayersScoreHistoryAsync(Guid playerID)
        {
            return await Request.ExecuteAsyncRequest<ListScoreHistoryResponse>(
                Config.EndPointPaths.Scores.ListScoreHistory,
                service,
                ListScoreHistoryBase.BuildFormData(null, playerID)
            );
        }

        /// <summary>
        /// Lists a Scores history
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-history" />
        [UsedImplicitly]
        public ListScoreHistoryResponse ListScoreHistory(Guid scoreID)
        {
            return Request.ExecuteSyncRequest<ListScoreHistoryResponse>(
                Config.EndPointPaths.Scores.ListScoreHistory,
                service,
                ListScoreHistoryBase.BuildFormData(scoreID, null)
            );
        }

        /// <summary>
        /// Lists a Scores history
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-history" />
        [UsedImplicitly]
        public async Task<ListScoreHistoryResponse> ListScoreHistoryAsync(Guid scoreID)
        {
            return await Request.ExecuteAsyncRequest<ListScoreHistoryResponse>(
                Config.EndPointPaths.Scores.ListScoreHistory,
                service,
                ListScoreHistoryBase.BuildFormData(scoreID, null)
            );
        }
    }
    
    private static class ListScoreHistoryBase
    {
        internal static Dictionary<string, string> BuildFormData(Guid? scoreID, Guid? playerID)
        {
            var formData = new Dictionary<string, string>();
            if (playerID.HasValue)
            {
                formData.Add("playerID", playerID.ToString());
            }
            if (scoreID.HasValue)
            {
                formData.Add("scoreID", scoreID.ToString());
            }
            return formData;
        }
    }
}