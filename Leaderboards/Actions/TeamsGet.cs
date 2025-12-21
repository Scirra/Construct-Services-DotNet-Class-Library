using ConstructServices.Common;
using ConstructServices.Leaderboards.Enums;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    [UsedImplicitly]
    public static GetTeamsResponse GetAllTeams(
        this LeaderboardService service,
        GetTeamsOrdering ordering,
        PaginationOptions paginationOptions)
    {
        const string path = "/getteams.json";
        return Task.Run(() => Request.ExecuteRequest<GetTeamsResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "order", ordering.ToString() }
            },
            paginationOptions
        )).Result;
    }
}