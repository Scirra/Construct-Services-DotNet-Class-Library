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
        /// Create a new Score on a Leaderboard
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/post-score" />
        [UsedImplicitly]
        public CreateScoreResponse CreateScore(
            Guid playerID,
            CreateScoreOptions createScoreOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = createScoreOptions.BuildFormData(service.LeaderboardID, playerID);
            service.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<CreateScoreResponse>(
                Config.EndPointPaths.Scores.Create,
                service,
                formData
            );
        }

        /// <summary>
        /// Create a new Score on a Leaderboard
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/post-score" />
        [UsedImplicitly]
        public async Task<CreateScoreResponse> CreateScoreAsync(
            Guid playerID,
            CreateScoreOptions createScoreOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = createScoreOptions.BuildFormData(service.LeaderboardID, playerID);
            service.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<CreateScoreResponse>(
                Config.EndPointPaths.Scores.Create,
                service,
                formData
            );
        }
    }

    extension(PlayerLeaderboardService service)
    {        
        /// <summary>
        /// Create a new Score on a Leaderboard
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/post-score" />
        [UsedImplicitly]
        public CreateScoreResponse CreateScore(
            CreateScoreOptions createScoreOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = createScoreOptions.BuildFormData(service.LeaderboardID);
            service.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<CreateScoreResponse>(
                Config.EndPointPaths.Scores.Create,
                service,
                formData
            );
        }

        /// <summary>
        /// Create a new Score on a Leaderboard
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/scores/post-score" />
        [UsedImplicitly]
        public async Task<CreateScoreResponse> CreateScoreAsync(
            CreateScoreOptions createScoreOptions,
            RequestPerspective requestPerspective = null)
        {
            var formData = createScoreOptions.BuildFormData(service.LeaderboardID);
            service.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<CreateScoreResponse>(
                Config.EndPointPaths.Scores.Create,
                service,
                formData
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class CreateScoreOptions
    {
        private string RequesterIP { get; }
        private long Score { get; }
        private short? OptValue1 { get; }
        private short? OptValue2 { get; }
        private short? OptValue3 { get; }
        
        public CreateScoreOptions(
            string requesterIP,
            long score,
            short? optValue1,
            short? optValue2,
            short? optValue3)
        {
            RequesterIP = requesterIP;
            Score = score;
            OptValue1 = optValue1;
            OptValue2 = optValue2;
            OptValue3 = optValue3;
        }
        public CreateScoreOptions(
            long score,
            short? optValue1,
            short? optValue2,
            short? optValue3)
        {
            Score = score;
            OptValue1 = optValue1;
            OptValue2 = optValue2;
            OptValue3 = optValue3;
        }

        internal Dictionary<string, string> BuildFormData(Guid leaderboardID, Guid? playerID = null)
        {            
            var timestamp = ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();
            var hash = Functions.GetSHA256Hash(leaderboardID + "." + Score + "." + timestamp + "." + playerID);

            var formData = new Dictionary<string, string>
            {
                { "hash", hash },
                { "timestamp", timestamp.ToString() },
                { "score", Score.ToString() }
            };
            if (playerID.HasValue)
            {
                formData.Add("playerID", playerID.Value.ToString());
            }
            if (!string.IsNullOrWhiteSpace(RequesterIP))
            {
                formData.Add("requesterIP", RequesterIP);
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