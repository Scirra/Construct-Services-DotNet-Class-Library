using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Scores
{
    private const string PostScoreAPIPath = "/postscore.json";

    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public PostScoreResponse PostNewScore(
            long score,
            string strPlayerID,
            short? optValue1,
            short? optValue2,
            short? optValue3,
            RequestPerspective requestPerspective = null)
        {
            return service.DoPostNewScore(null, score, strPlayerID, optValue1, optValue2, optValue3,
                requestPerspective);
        }

        [UsedImplicitly]
        public async Task<PostScoreResponse> PostNewScoreAsync(
            long score,
            string strPlayerID,
            short? optValue1,
            short? optValue2,
            short? optValue3,
            RequestPerspective requestPerspective = null)
        {
            return await service.DoPostNewScoreAsync(null, score, strPlayerID, optValue1, optValue2, optValue3,
                requestPerspective);
        }

        [UsedImplicitly]
        public PostScoreResponse PostNewScore(
            string sessionKey,
            long score,
            string strPlayerID,
            short? optValue1,
            short? optValue2,
            short? optValue3,
            RequestPerspective requestPerspective = null)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new PostScoreResponse(sessionKeyValidator.ErrorMessage);
            }

            return service.DoPostNewScore(sessionKey, score, strPlayerID, optValue1, optValue2, optValue3,
                requestPerspective);
        }

        [UsedImplicitly]
        public async Task<PostScoreResponse> PostNewScoreAsync(
            string sessionKey,
            long score,
            string strPlayerID,
            short? optValue1,
            short? optValue2,
            short? optValue3,
            RequestPerspective requestPerspective = null)
        {
            var sessionKeyValidator = Common.Validations.PlayerSessionKey.ValidatePlayerSessionKey(sessionKey);
            if (!sessionKeyValidator.Successfull)
            {
                return new PostScoreResponse(sessionKeyValidator.ErrorMessage);
            }

            return await service.DoPostNewScoreAsync(sessionKey, score, strPlayerID, optValue1, optValue2, optValue3,
                requestPerspective);
        }
        
        private PostScoreResponse DoPostNewScore(string sessionKey,
            long score,
            string strPlayerID,
            short? optValue1,
            short? optValue2,
            short? optValue3,
            RequestPerspective requestPerspective = null)
        {
            strPlayerID = (strPlayerID ?? string.Empty).Trim();

            var timestamp = ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();
            var hash = Functions.GetSHA256Hash(service.LeaderboardID + "." + score + "." + timestamp + "." + strPlayerID);

            var formData = new Dictionary<string, string>
            {
                { "hash", hash },
                { "score", score.ToString() },
                { "timestamp", timestamp.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(sessionKey))
            {
                formData.Add("sessionKey", sessionKey);
            }
            if (!string.IsNullOrWhiteSpace(strPlayerID))
            {
                var idValidator = Common.Validations.Guid.IsValidGuid(strPlayerID);
                if (!idValidator.Successfull)
                {
                    return new PostScoreResponse(string.Format(idValidator.ErrorMessage, "Player ID"));
                }
                formData.Add("playerID", strPlayerID);
            }
            if (optValue1.HasValue)
            {
                formData.Add("opt1", optValue1.Value.ToString());
            }
            if (optValue2.HasValue)
            {
                formData.Add("opt2", optValue2.Value.ToString());
            }
            if (optValue3.HasValue)
            {
                formData.Add("opt3", optValue3.Value.ToString());
            }

            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return Request.ExecuteSyncRequest<PostScoreResponse>(
                PostScoreAPIPath,
                service,
                formData
            );
        }

        private async Task<PostScoreResponse> DoPostNewScoreAsync(string sessionKey,
            long score,
            string strPlayerID,
            short? optValue1,
            short? optValue2,
            short? optValue3,
            RequestPerspective requestPerspective = null)
        {
            strPlayerID = (strPlayerID ?? string.Empty).Trim();

            var timestamp = ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();
            var hash = Functions.GetSHA256Hash(service.LeaderboardID + "." + score + "." + timestamp + "." + strPlayerID);

            var formData = new Dictionary<string, string>
            {
                { "hash", hash },
                { "score", score.ToString() },
                { "timestamp", timestamp.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(sessionKey))
            {
                formData.Add("sessionKey", sessionKey);
            }
            if (!string.IsNullOrWhiteSpace(strPlayerID))
            {
                var idValidator = Common.Validations.Guid.IsValidGuid(strPlayerID);
                if (!idValidator.Successfull)
                {
                    return new PostScoreResponse(string.Format(idValidator.ErrorMessage, "Player ID"));
                }
                formData.Add("playerID", strPlayerID);
            }
            if (optValue1.HasValue)
            {
                formData.Add("opt1", optValue1.Value.ToString());
            }
            if (optValue2.HasValue)
            {
                formData.Add("opt2", optValue2.Value.ToString());
            }
            if (optValue3.HasValue)
            {
                formData.Add("opt3", optValue3.Value.ToString());
            }

            LeaderboardService.AddRequestPerspectiveFormData(requestPerspective, formData);

            return await Request.ExecuteAsyncRequest<PostScoreResponse>(
                PostScoreAPIPath,
                service,
                formData
            );
        }
    }
}