using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class ShadowBans
{
    [UsedImplicitly]
    public static GetShadowBansResponse GetPlayerIDShadowBans(
        this LeaderboardService service,
        PaginationOptions paginationOptions)
    {
        const string path = "/getplayeridshadowbans.json";
        var formData = new Dictionary<string, string>();
        return Task.Run(() => Request.ExecuteRequest<GetShadowBansResponse>(
            path,
            service,
            formData,
            paginationOptions
        )).Result;
    }
}