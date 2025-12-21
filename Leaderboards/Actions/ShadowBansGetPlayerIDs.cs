using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class ShadowBans
{
    private const string GetPlayerIDShadowBansAPIPath = "/getplayeridshadowbans.json";
    
    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public GetShadowBansResponse GetPlayerIDShadowBans(PaginationOptions paginationOptions)
        {
            var formData = new Dictionary<string, string>();
            return Request.ExecuteSyncRequest<GetShadowBansResponse>(
                GetPlayerIDShadowBansAPIPath,
                service,
                formData,
                paginationOptions
            );
        }

        [UsedImplicitly]
        public async Task<GetShadowBansResponse> GetPlayerIDShadowBansAsync(PaginationOptions paginationOptions)
        {
            var formData = new Dictionary<string, string>();
            return await Request.ExecuteAsyncRequest<GetShadowBansResponse>(
                GetPlayerIDShadowBansAPIPath,
                service,
                formData,
                paginationOptions
            );
        }
    }
}