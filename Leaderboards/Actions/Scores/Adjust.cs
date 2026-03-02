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
        /// Adjust an existing Score for a player.  If Score ID is not specified, Players best score will be updated.
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public PostScoreResponse AdjustPlayersScore(AdjustPlayersScoreOptions adjustPlayersScoreOptions)
        {
            return Request.ExecuteSyncRequest<PostScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustPlayersScoreOptions.BuildFormData(service.LeaderboardID)
            );
        }
        
        /// <summary>
        /// Adjust an existing Score for a player.  If Score ID is not specified, Players best score will be updated.
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public async Task<PostScoreResponse> AdjustPlayersScoreAsync(AdjustPlayersScoreOptions adjustPlayersScoreOptions)
        {
            return await Request.ExecuteAsyncRequest<PostScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustPlayersScoreOptions.BuildFormData(service.LeaderboardID)
            );
        }

        /// <summary>
        /// Adjust an existing Score.
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public PostScoreResponse AdjustScoreByID(AdjustScoreByIDOptions adjustScoreByIDOptions)
        {
            return Request.ExecuteSyncRequest<PostScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustScoreByIDOptions.BuildFormData(service.LeaderboardID)
            );
        }

        /// <summary>
        /// Adjust an existing Score.
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/adjust-score" />
        [UsedImplicitly]
        public async Task<PostScoreResponse> AdjustScoreByIDAsync(AdjustScoreByIDOptions adjustScoreByIDOptions)
        {
            return await Request.ExecuteAsyncRequest<PostScoreResponse>(
                Config.EndPointPaths.Scores.Adjust,
                service,
                adjustScoreByIDOptions.BuildFormData(service.LeaderboardID)
            );
        }
    }

    [UsedImplicitly]
    public abstract class AdjustScoreBase(
        string sessionKey,
        Guid? playerID,
        Guid? scoreID,
        long adjustment,
        short? optValue1,
        short? optValue2,
        short? optValue3)
    {
        private string SessionKey { get; } = sessionKey;
        private Guid? ScoreID { get; } = scoreID;
        private Guid? PlayerID { get; } = playerID;
        private long Adjustment { get; } = adjustment;
        private short? OptValue1 { get; } = optValue1;
        private short? OptValue2 { get; } = optValue2;
        private short? OptValue3 { get; } = optValue3;

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
    public sealed class AdjustScoreByIDOptions(
        Guid scoreID,
        long adjustment,
        short? optValue1,
        short? optValue2,
        short? optValue3)
        : AdjustScoreBase(null, null, scoreID, adjustment, optValue1, optValue2, optValue3);

    [UsedImplicitly]
    public sealed class AdjustPlayersScoreOptions : AdjustScoreBase
    {    public AdjustPlayersScoreOptions(
            string sessionKey,
            Guid playerID,
            Guid scoreID,
            long adjustment,
            short? optValue1,
            short? optValue2,
            short? optValue3) :
            base(sessionKey, playerID, scoreID, adjustment, optValue1, optValue2, optValue3) { }
        public AdjustPlayersScoreOptions(
            string sessionKey,
            Guid playerID,
            long adjustment,
            short? optValue1,
            short? optValue2,
            short? optValue3) :
            base(sessionKey, playerID, null, adjustment, optValue1, optValue2, optValue3) { }
        public AdjustPlayersScoreOptions(
            Guid playerID,
            Guid scoreID,
            long adjustment,
            short? optValue1,
            short? optValue2,
            short? optValue3) :
            base(null, playerID, scoreID, adjustment, optValue1, optValue2, optValue3) { }
        public AdjustPlayersScoreOptions(
            Guid playerID,
            long adjustment,
            short? optValue1,
            short? optValue2,
            short? optValue3) :
            base(null, playerID, null, adjustment, optValue1, optValue2, optValue3) { }
    }
}