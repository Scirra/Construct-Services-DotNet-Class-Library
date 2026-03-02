using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class ShadowBans
{
    
    extension(LeaderboardService service)
    {
        /// <summary>
        /// List all Player ID based Shadow Bans
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/get-player-bans" />
        [UsedImplicitly]
        public GetShadowBansResponse GetPlayerIDShadowBans(
            ListShadowBanOptions listShadowBanOptions, 
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<GetShadowBansResponse>(
                Config.EndPointPaths.ShadowBans.ListPlayerIDBans,
                service,
                listShadowBanOptions.BuildFormData(),
                paginationOptions
            );
        }

        /// <summary>
        /// List all Player ID based Shadow Bans
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/get-player-bans" />
        [UsedImplicitly]
        public async Task<GetShadowBansResponse> GetPlayerIDShadowBansAsync(
            ListShadowBanOptions listShadowBanOptions, 
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<GetShadowBansResponse>(
                Config.EndPointPaths.ShadowBans.ListPlayerIDBans,
                service,
                listShadowBanOptions.BuildFormData(),
                paginationOptions
            );
        }
    }
}