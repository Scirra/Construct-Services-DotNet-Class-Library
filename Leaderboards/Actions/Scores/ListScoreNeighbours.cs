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
        /// List Score neighbours for a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-neighbours" />
        [UsedImplicitly]
        public ScoresResponse ListPlayersScoreNeighbours(
            ListPlayerScoreNeighboursOptions listPlayerScoreNeighboursOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listPlayerScoreNeighboursOptions.BuildFormData();
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<ScoresResponse>(
                Config.EndPointPaths.Scores.ListScoreNeighbours,
                service,
                formData
            );
        }        
        
        /// <summary>
        /// List Score neighbours for a Player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-neighbours" />
        [UsedImplicitly]
        public async Task<ScoresResponse> ListPlayersScoreNeighboursAsync(
            ListPlayerScoreNeighboursOptions listPlayerScoreNeighboursOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listPlayerScoreNeighboursOptions.BuildFormData();
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<ScoresResponse>(
                Config.EndPointPaths.Scores.ListScoreNeighbours,
                service,
                formData
            );
        }        
        
        /// <summary>
        /// List Score neighbours for a Score
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-neighbours" />
        [UsedImplicitly]
        public ScoresResponse ListScoreNeighbours(
            ListScoreNeighboursOptions listScoreNeighboursOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listScoreNeighboursOptions.BuildFormData();
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<ScoresResponse>(
                Config.EndPointPaths.Scores.ListScoreNeighbours,
                service,
                formData
            );
        }

        /// <summary>
        /// List Score neighbours for a Score
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/get-score-neighbours" />
        [UsedImplicitly]
        public async Task<ScoresResponse> ListScoreNeighboursAsync(
            ListScoreNeighboursOptions listScoreNeighboursOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listScoreNeighboursOptions.BuildFormData();
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<ScoresResponse>(
                Config.EndPointPaths.Scores.ListScoreNeighbours,
                service,
                formData
            );
        }
    }
    
    [UsedImplicitly]
    public abstract class ListNeighbourScoresBase(Guid? playerID, Guid? scoreID, short? range, short? compareRanks)
    {
        private Guid? PlayerID { get; } = playerID;
        private Guid? ScoreID { get; } = scoreID;
        private short? Range { get; } = range;
        private short? CompareRanks { get; } = compareRanks;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (PlayerID.HasValue)
            {
                formData.Add("playerID", PlayerID.Value.ToString());
            }
            if (ScoreID.HasValue)
            {
                formData.Add("scoreID", ScoreID.Value.ToString());
            }
            if (Range.HasValue)
            {
                formData.Add("range", Range.Value.ToString());
            }
            if (CompareRanks.HasValue)
            {
                formData.Add("compareRanks", CompareRanks.Value.ToString());
            }
            return formData;
        }
    }

    [UsedImplicitly]
    public sealed class ListPlayerScoreNeighboursOptions(
        Guid playerID,
        short? range,
        short? compareRanks)
        : ListNeighbourScoresBase(playerID, null, range, compareRanks);

    [UsedImplicitly]
    public sealed class ListScoreNeighboursOptions(
        Guid scoreID, 
        short? range, 
        short? compareRanks)
        : ListNeighbourScoresBase(null, scoreID, range, compareRanks);


}