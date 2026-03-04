using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    extension(LeaderboardService service)
    {
        /// <summary>
        /// Adjust an existing Score.
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public PostScoreResponse AdjustScore(AdjustScoreBase adjustScoreOptions)
        {
            return Request.ExecuteSyncRequest<PostScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustScoreOptions.BuildFormData(service.LeaderboardID)
            );
        }
        
        /// <summary>
        /// Adjust an existing Score.
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public async Task<PostScoreResponse> AdjustScoreScoreAsync(AdjustScoreBase adjustScoreOptions)
        {
            return await Request.ExecuteAsyncRequest<PostScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustScoreOptions.BuildFormData(service.LeaderboardID)
            );
        }
    }

    [UsedImplicitly]
    public abstract class AdjustScoreBase
    {
        internal string SessionKey { get; set; }
        internal Guid? ScoreID { get; set; }
        internal Guid? PlayerID { get; set; }

        public long Adjustment { get; set; }
        public short? OptValue1 { get; set; }
        public short? OptValue2 { get; set; }
        public short? OptValue3 { get; set; }

        internal Dictionary<string, string> BuildFormData(Guid leaderboardID)
        {            
            var timestamp = ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();
            var hash = Functions.GetSHA256Hash(leaderboardID + "." + Adjustment + "." + ScoreID + "." + timestamp + ".");

            var formData = new Dictionary<string, string>
            {
                { "hash", hash },
                { "timestamp", timestamp.ToString() },
                { "adjustment", Adjustment.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(SessionKey))
            {
                formData.Add("sessionKey", SessionKey);
            }
            if (PlayerID.HasValue)
            {
                formData.Add("playerID", PlayerID.Value.ToString());
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

    [UsedImplicitly]
    public sealed class AdjustScoreByIDOptions : AdjustScoreBase
    {
        public AdjustScoreByIDOptions(Guid scoreID)
        {
            ScoreID = scoreID;
        }
    }

    [UsedImplicitly]
    public sealed class AdjustPlayersScoreOptions : AdjustScoreBase
    {
        public AdjustPlayersScoreOptions(Guid playerID)
        {
            PlayerID = playerID;
        }
        public AdjustPlayersScoreOptions(string sessionKey)
        {
            SessionKey = sessionKey;
        }
    }
}