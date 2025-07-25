using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class ShadowBans
{
    public static GetShadowBansResponse GetPlayerIDShadowBans(
        this LeaderboardService service,
        PaginationOptions paginationOptions)
    {
        const string path = "/getplayeridshadowbans.json";
        var formData = new Dictionary<string, string>();
        return Task.Run(() => Request.ExecuteLeaderboardRequest<GetShadowBansResponse>(
            path,
            service,
            formData,
            null,
            paginationOptions
        )).Result;
    }
}