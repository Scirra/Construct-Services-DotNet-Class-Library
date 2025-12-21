using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class ShadowBans
{
    [UsedImplicitly]
    public static GetShadowBansResponse GetIPShadowBans(
        this LeaderboardService service,
        PaginationOptions paginationOptions)
    {
        const string path = "/getipshadowbans.json";
        var formData = new Dictionary<string, string>();
        return Request.ExecuteSyncRequest<GetShadowBansResponse>(
            path,
            service,
            formData,
            paginationOptions
        );
    }
}