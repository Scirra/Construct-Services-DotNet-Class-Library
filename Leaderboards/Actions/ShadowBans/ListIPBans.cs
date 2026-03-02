using ConstructServices.Leaderboards.Responses;
using System.Threading.Tasks;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static partial class ShadowBans
{
    
    extension(LeaderboardService service)
    {
        /// <summary>
        /// List all IP based Shadow Bans
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/get-ip-bans" />
        [UsedImplicitly]
        public GetShadowBansResponse ListIPShadowBans(
            ListShadowBanOptions listShadowBanOptions, 
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<GetShadowBansResponse>(
                Config.EndPointPaths.ShadowBans.ListIPBans,
                service,
                listShadowBanOptions.BuildFormData(),
                paginationOptions
            );
        }

        /// <summary>
        /// List all IP based Shadow Bans
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/get-ip-bans" />
        [UsedImplicitly]
        public async Task<GetShadowBansResponse> ListIPShadowBansAsync(
            ListShadowBanOptions listShadowBanOptions, 
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<GetShadowBansResponse>(
                Config.EndPointPaths.ShadowBans.ListIPBans,
                service,
                listShadowBanOptions.BuildFormData(),
                paginationOptions
            );
        }
    }
}