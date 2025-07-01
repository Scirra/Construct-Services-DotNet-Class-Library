using ConstructServices.Leaderboards.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions
{
    public static partial class Scores
    {
        public static GetScoreNeighboursResponse GetScoreNeighbours(
            this LeaderboardService service,
            string playerID,
            int range = 5,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
            => Execute(service, playerID, null, range, compareRanks, requestPerspective);

        public static GetScoreNeighboursResponse GetScoreNeighbours(
            this LeaderboardService service,
            Guid scoreID,
            int range = 5,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
            => Execute(service, null, scoreID, range, compareRanks, requestPerspective);
        private static GetScoreNeighboursResponse Execute(
            LeaderboardService service,
            string playerID,
            Guid? scoreID,
            int range,
            int? compareRanks = null,
            RequestPerspective requestPerspective = null)
        {
            const string path = "/getscoreneighbours.json";
            var formData = new Dictionary<string, string>
            {
                { "range", range.ToString() }
            };
            if (!string.IsNullOrWhiteSpace(playerID))
            {
                formData.Add("playerID", playerID);
            }
            if (scoreID.HasValue)
            {
                formData.Add("scoreID", scoreID.Value.ToString());
            }
            if (compareRanks.HasValue)
            {
                formData.Add("compareRanks", compareRanks.Value.ToString());
            }
            return Task.Run(() => Request.ExecuteLeaderboardRequest<GetScoreNeighboursResponse>(
                path,
                service,
                formData,
                requestPerspective
            )).Result;
        }
    }
}
