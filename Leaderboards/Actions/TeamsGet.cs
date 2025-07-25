using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    public static GetTeamsResponse GetAllTeams(
        this LeaderboardService service,
        PaginationOptions paginationOptions)
    {
        const string path = "/getteams.json";
        var formData = new Dictionary<string, string>();
        return Task.Run(() => Request.ExecuteLeaderboardRequest<GetTeamsResponse>(
            path,
            service,
            formData,
            null,
            paginationOptions
        )).Result;
    }
}