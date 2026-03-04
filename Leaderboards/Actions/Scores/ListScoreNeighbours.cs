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
            Guid playerID,
            ListScoreNeighbourOptions listPlayerScoreNeighboursOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listPlayerScoreNeighboursOptions.BuildPlayerFormData(playerID);
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
            Guid playerID,
            ListScoreNeighbourOptions listPlayerScoreNeighboursOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listPlayerScoreNeighboursOptions.BuildPlayerFormData(playerID);
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
            Guid scoreID,
            ListScoreNeighbourOptions listScoreNeighboursOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listScoreNeighboursOptions.BuildScoreIDFormData(scoreID);
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
            Guid scoreID,
            ListScoreNeighbourOptions listScoreNeighboursOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = listScoreNeighboursOptions.BuildScoreIDFormData(scoreID);
            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<ScoresResponse>(
                Config.EndPointPaths.Scores.ListScoreNeighbours,
                service,
                formData
            );
        }
    }
    
    [UsedImplicitly]
    public class ListScoreNeighbourOptions
    {
        [UsedImplicitly]
        public short? Range { get; set; }

        [UsedImplicitly]
        public short? CompareRanks { get; set; }

        internal Dictionary<string, string> BuildPlayerFormData(Guid playerID)
        {
            var formData = new Dictionary<string, string>
            {
                {"playerID", playerID.ToString() }
            };
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

        internal Dictionary<string, string> BuildScoreIDFormData(Guid scoreID)
        {
            var formData = new Dictionary<string, string>
            {
                {"scoreID", scoreID.ToString() }
            };
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
}