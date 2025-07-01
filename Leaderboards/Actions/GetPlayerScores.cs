using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions
{
    public static partial class Scores
    {
        public static GetScoreResponse GetPlayerScores(
            this LeaderboardService service,
            string playerID,
            PaginationOptions paginationOptions)
        {
            const string path = "/getplayerscores.json";
            var formData = new Dictionary<string, string>
            {
                { "playerID", playerID }
            };
            return Task.Run(() => Request.ExecuteLeaderboardRequest<GetScoreResponse>(
                path,
                service,
                formData,
                null,
                paginationOptions
            )).Result;
        }
    }
}
