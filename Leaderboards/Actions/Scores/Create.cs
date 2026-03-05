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
            LeaderboardServiceBase.AddRequestPerspectiveFormData(requestPerspective, formData);

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
            LeaderboardServiceBase.AddRequestPerspectiveFormData(requestPerspective, formData);

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
            LeaderboardServiceBase.AddRequestPerspectiveFormData(requestPerspective, formData);

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
            LeaderboardServiceBase.AddRequestPerspectiveFormData(requestPerspective, formData);

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
        [UsedImplicitly]
        public string RequesterIP { private get; set; }

        [UsedImplicitly]
        public long Score { private get; set; }

        [UsedImplicitly]
        public short? OptValue1 { private get; set; }

        [UsedImplicitly]
        public short? OptValue2 { private get; set; }

        [UsedImplicitly]
        public short? OptValue3 { private get; set; }

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