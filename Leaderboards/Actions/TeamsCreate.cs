using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions
{
    public static partial class Teams
    {
        public static CreateTeamResponse CreateNewTeam(
            this LeaderboardService service,
            string teamName)
        {
            const string path = "/createteam.json";
            return Task.Run(() => Request.ExecuteLeaderboardRequest<CreateTeamResponse>(
                path,
                service,
                new Dictionary<string, string>
                {
                    { "teamName", teamName },
                }
            )).Result;
        }
    }
}
