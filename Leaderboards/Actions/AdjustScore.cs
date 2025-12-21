using ConstructServices.Common;
using ConstructServices.Common.Validations;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Guid = System.Guid;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    private const string AdjustScoreAPIPath = "/adjustscore.json";

    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public PostScoreResponse AdjustExistingScore(
            Guid scoreID,
            long adjustment,
            short optValue1 = 0,
            short optValue2 = 0,
            short optValue3 = 0)
        {
            return service.DoAdjustExistingScore(null, scoreID, adjustment, optValue1, optValue2, optValue3);
        }

        [UsedImplicitly]
        public async Task<PostScoreResponse> AdjustExistingScoreAsync(
            string sessionKey,
            Guid scoreID,
            long adjustment,
            short optValue1 = 0,
            short optValue2 = 0,
            short optValue3 = 0)
        {
            var sessionKeyValidator = sessionKey.ValidatePlayerSessionKey();
            if (!sessionKeyValidator.Successfull)
            {
                return new PostScoreResponse(sessionKeyValidator.ErrorMessage);
            }
            return await service.DoAdjustExistingScoreAsync(sessionKey, scoreID, adjustment, optValue1, optValue2, optValue3);
        }

        private PostScoreResponse DoAdjustExistingScore(
            string sessionKey,
            Guid scoreID,
            long adjustment,
            short optValue1 = 0,
            short optValue2 = 0,
            short optValue3 = 0)
        {
            var timestamp = ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();
            var hash = Functions.GetSHA256Hash(service.LeaderboardID + "." + adjustment + "." + scoreID + "." + timestamp + ".");

            var formData = new Dictionary<string, string>
            {
                { "hash", hash },
                { "adjustment", adjustment.ToString() },
                { "timestamp", timestamp.ToString() },
                { "scoreID", scoreID.ToString() },
                { "sessionKey", sessionKey }
            };
            if (optValue1 != 0)
            {
                formData.Add("opt1", optValue1.ToString());
            }
            if (optValue2 != 0)
            {
                formData.Add("opt2", optValue2.ToString());
            }
            if (optValue3 != 0)
            {
                formData.Add("opt3", optValue3.ToString());
            }
            return Request.ExecuteSyncRequest<PostScoreResponse>(
                AdjustScoreAPIPath,
                service,
                formData
            );
        }

        private async Task<PostScoreResponse> DoAdjustExistingScoreAsync(
            string sessionKey,
            Guid scoreID,
            long adjustment,
            short optValue1 = 0,
            short optValue2 = 0,
            short optValue3 = 0)
        {
            var timestamp = ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();
            var hash = Functions.GetSHA256Hash(service.LeaderboardID + "." + adjustment + "." + scoreID + "." + timestamp + ".");

            var formData = new Dictionary<string, string>
            {
                { "hash", hash },
                { "adjustment", adjustment.ToString() },
                { "timestamp", timestamp.ToString() },
                { "scoreID", scoreID.ToString() },
                { "sessionKey", sessionKey }
            };
            if (optValue1 != 0)
            {
                formData.Add("opt1", optValue1.ToString());
            }
            if (optValue2 != 0)
            {
                formData.Add("opt2", optValue2.ToString());
            }
            if (optValue3 != 0)
            {
                formData.Add("opt3", optValue3.ToString());
            }
            return await Request.ExecuteAsyncRequest<PostScoreResponse>(
                AdjustScoreAPIPath,
                service,
                formData
            );
        }
    }
}