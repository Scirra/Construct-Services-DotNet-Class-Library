using System;
using ConstructServices.Authentication.Enums;
using ConstructServices.Authentication.Responses;
using ConstructServices.Leaderboards;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static GetPlayersResponse GetPlayers(
        this AuthenticationService service,
        PlayerOrdering ordering,
        PaginationOptions paginationOptions)
    {
        const string path = "/getplayers.json";

        var formData = new Dictionary<string, string>();

        // Pagination
        if (paginationOptions != null)
        {
            formData.Add("page", paginationOptions.RequestedPage.ToString());
            if (paginationOptions.RecordsPerPage.HasValue)
            {
                formData.Add("perPage", paginationOptions.RecordsPerPage.Value.ToString());
            }
        }

        formData.Add("order", ordering.ToString());

        return Task.Run(() => Request.ExecuteAuthenticationRequest<GetPlayersResponse>(
            path,
            service,
            formData
        )).Result;
    }
    
    [UsedImplicitly]
    public static GetPlayersResponse GetPlayers(
        this AuthenticationService service,
        Guid playerID)
        => GetPlayers(service, [playerID]);

    [UsedImplicitly]
    public static GetPlayersResponse GetPlayers(
        this AuthenticationService service,
        List<Guid> playerIDs)
    {
        const string path = "/getplayers.json";
        var formData = new Dictionary<string, string>
        {
            { "playerIDs", string.Join(",", playerIDs) }
        };
        return Task.Run(() => Request.ExecuteAuthenticationRequest<GetPlayersResponse>(
            path,
            service,
            formData
        )).Result;
    }
}