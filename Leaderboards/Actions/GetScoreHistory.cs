using System;
using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions
{
    public static partial class Scores
    {
        public static GetScoreHistoryResponse GetPlayersScoreHistory(
            this LeaderboardService service,
            string playerID)
        {
            const string path = "/getscorehistory.json";
            var formData = new Dictionary<string, string>
            {
                { "playerID", playerID },
            };
            return Task.Run(() => Request.ExecuteLeaderboardRequest<GetScoreHistoryResponse>(
                path,
                service,
                formData
            )).Result;
        }
        
        public static GetScoreHistoryResponse GetScoreHistoryOnScoreID(
            this LeaderboardService service,
            string strScoreID)
        {
            if (string.IsNullOrWhiteSpace(strScoreID))
                return new GetScoreHistoryResponse("No Score ID was provided.", false);
            if (!Guid.TryParse(strScoreID, out var scoreID))
                return new GetScoreHistoryResponse("Score ID was not a valid GUID.", false);
            return GetScoreHistoryOnScoreID(service, scoreID);
        }
        public static GetScoreHistoryResponse GetScoreHistoryOnScoreID(
            this LeaderboardService service,
            Guid scoreID)
        {
            const string path = "/getscorehistory.json";
            var formData = new Dictionary<string, string>
            {
                { "scoreID", scoreID.ToString() },
            };
            return Task.Run(() => Request.ExecuteLeaderboardRequest<GetScoreHistoryResponse>(
                path,
                service,
                formData
            )).Result;
        }
    }
}
