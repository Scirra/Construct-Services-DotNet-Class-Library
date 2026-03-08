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
        /// Adjust existing Score
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public CreateScoreResponse AdjustScore(Guid scoreID, AdjustScoreOptions adjustScoreOptions)
        {
            return Request.ExecuteSyncRequest<CreateScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustScoreOptions.BuildFormData(service.LeaderboardID, scoreID, null)
            );
        }
        
        /// <summary>
        /// Adjust existing Score
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public async Task<CreateScoreResponse> AdjustScoreAsync(Guid scoreID, AdjustScoreOptions adjustScoreOptions)
        {
            return await Request.ExecuteAsyncRequest<CreateScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustScoreOptions.BuildFormData(service.LeaderboardID, scoreID, null)
            );
        }
    }
    
    extension(LeaderboardService service)
    {
        /// <summary>
        /// Adjust current best score
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public CreateScoreResponse AdjustBestScore(Guid playerID, AdjustScoreOptions adjustScoreOptions)
        {
            return Request.ExecuteSyncRequest<CreateScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustScoreOptions.BuildFormData(service.LeaderboardID, null, playerID)
            );
        }
        
        /// <summary>
        /// Adjust current best score
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public async Task<CreateScoreResponse> AdjustBestScoreAsync(Guid playerID, AdjustScoreOptions adjustScoreOptions)
        {
            return await Request.ExecuteAsyncRequest<CreateScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustScoreOptions.BuildFormData(service.LeaderboardID, null, playerID)
            );
        }
    }

    extension(PlayerLeaderboardService service)
    {
        /// <summary>
        /// Adjust current best score
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public CreateScoreResponse AdjustBestScore(AdjustScoreOptions adjustScoreOptions)
        {
            return Request.ExecuteSyncRequest<CreateScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustScoreOptions.BuildFormData(service.LeaderboardID, null, null)
            );
        }
        
        /// <summary>
        /// Adjust current best score
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public async Task<CreateScoreResponse> AdjustBestScoreAsync(AdjustScoreOptions adjustScoreOptions)
        {
            return await Request.ExecuteAsyncRequest<CreateScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustScoreOptions.BuildFormData(service.LeaderboardID, null, null)
            );
        }
    }

    [UsedImplicitly]
    public sealed class AdjustScoreOptions
    {
        [UsedImplicitly]
        public long Adjustment { private get; set; }

        [UsedImplicitly]
        public short? OptValue1 { private get; set; }

        [UsedImplicitly]
        public short? OptValue2 { private get; set; }

        [UsedImplicitly]
        public short? OptValue3 { private get; set; }

        internal Dictionary<string, string> BuildFormData(Guid leaderboardID, Guid? scoreID, Guid? playerId)
        {            
            var timestamp = ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();
            var hash = Functions.GetSHA256Hash(leaderboardID + "." + Adjustment + "." + scoreID + "." + timestamp + ".");

            var formData = new Dictionary<string, string>
            {
                { "hash", hash },
                { "timestamp", timestamp.ToString() },
                { "adjustment", Adjustment.ToString() }
            };
            if (scoreID.HasValue)
            {
                formData.Add("scoreID", scoreID.Value.ToString());
            }
            if (playerId.HasValue)
            {
                formData.Add("playerID", playerId.Value.ToString());
            }
            if (OptValue1.HasValue)
            {
                formData.Add("opt1", OptValue1.Value.ToString());
            }
            if (OptValue2.HasValue)
            {
                formData.Add("opt2", OptValue2.Value.ToString());
            }
            if (OptValue3.HasValue)
            {
                formData.Add("opt3", OptValue3.Value.ToString());
            }
            return formData;
        }
    }
}