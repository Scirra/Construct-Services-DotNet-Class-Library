using ConstructServices.Leaderboards.Responses;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    [UsedImplicitly]
    public static GetTeamsResponse GetAllTeams(
        this LeaderboardService service,
        PaginationOptions paginationOptions)
    {
        const string path = "/getteams.json";
        return Task.Run(() => Request.ExecuteRequest<GetTeamsResponse>(
            path,
            service,
            null,
            paginationOptions
        )).Result;
    }
}