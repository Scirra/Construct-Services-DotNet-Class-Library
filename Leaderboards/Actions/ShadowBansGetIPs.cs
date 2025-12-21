using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class ShadowBans
{
    private const string GetIPShadowBansAPIPath = "/getipshadowbans.json";
    
    extension(LeaderboardService service)
    {
        [UsedImplicitly]
        public GetShadowBansResponse GetIPShadowBans(PaginationOptions paginationOptions)
        {
            var formData = new Dictionary<string, string>();
            return Request.ExecuteSyncRequest<GetShadowBansResponse>(
                GetIPShadowBansAPIPath,
                service,
                formData,
                paginationOptions
            );
        }

        [UsedImplicitly]
        public async Task<GetShadowBansResponse> GetIPShadowBansAsync(PaginationOptions paginationOptions)
        {
            var formData = new Dictionary<string, string>();
            return await Request.ExecuteAsyncRequest<GetShadowBansResponse>(
                GetIPShadowBansAPIPath,
                service,
                formData,
                paginationOptions
            );
        }
    }
}