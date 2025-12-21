using System;
using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class Teams
{
    [UsedImplicitly]
    public static GetTeamPlayersResponse GetTeamPlayers(
        this LeaderboardService service,
        PaginationOptions paginationOptions,
        Guid teamID,
        string order = null)
    {
        const string path = "/getteamplayers.json";

        var formData = new Dictionary<string, string>
        {
            { "teamID", teamID.ToString() }
        };
        if (!string.IsNullOrWhiteSpace(order))
        {
            formData.Add("order", order);
        }
        return Task.Run(() => Request.ExecuteRequest<GetTeamPlayersResponse>(
            path,
            service,
            formData,
            paginationOptions
        )).Result;
    }
}