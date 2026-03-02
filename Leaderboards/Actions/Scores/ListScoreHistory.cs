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

    
    [UsedImplicitly]
    public abstract class ListScoreHistoryBase(Guid? playerID, Guid? scoreID)
    {
        private Guid? PlayerID { get; } = playerID;
        private Guid? ScoreID { get; } = scoreID;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (PlayerID.HasValue)
            {
                formData.Add("playerID", PlayerID.ToString());
            }
            if (ScoreID.HasValue)
            {
                formData.Add("scoreID", ScoreID.ToString());
            }
            return formData;
        }
    }

    [UsedImplicitly]
    public sealed class ListPlayerScoreHistoryOptions(Guid playerID)
        : ListScoreHistoryBase(playerID, null);

    [UsedImplicitly]
    public sealed class ListScoreHistoryOptions(Guid scoreID)
        : ListScoreHistoryBase(null, scoreID);


}