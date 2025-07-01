using ConstructServices.Leaderboards.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions
{
    public static partial class Scores
    {
        public static PostScoreResponse PostNewScore(
            this LeaderboardService service,
            long score,
            string strPlayerID,
            short? optValue1,
            short? optValue2,
            short? optValue3,
            RequestPerspective requestPerspective = null)
        {
            const string path = "/postscore.json";

            strPlayerID = (strPlayerID ?? string.Empty).Trim();

            var timestamp = ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeSeconds();
            var hash = Common.Functions.GetSHA256Hash(service.LeaderboardID + "." + score + "." + timestamp + "." + strPlayerID);

            var formData = new Dictionary<string, string>
            {
                { "hash", hash },
                { "score", score.ToString() },
                { "timestamp", timestamp.ToString() },
            };

            if (!string.IsNullOrWhiteSpace(strPlayerID))
            {
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

            return Task.Run(() => Request.ExecuteLeaderboardRequest<PostScoreResponse>(
                path,
                service,
                formData,
                requestPerspective
            )).Result;
        }
    }
}
