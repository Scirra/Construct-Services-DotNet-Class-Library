using ConstructServices.Common;
using ConstructServices.Leaderboards.Enums;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Collections.Generic;

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
        return Request.ExecuteSyncRequest<GetTeamsResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "order", ordering.ToString() }
            },
            paginationOptions
        );
    }
}