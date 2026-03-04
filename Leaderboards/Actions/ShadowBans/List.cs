using System.Threading.Tasks;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions;

public static class List
{
    
    extension(LeaderboardService service)
    {
        /// <summary>
        /// List all IP based Shadow Bans
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/list-ip-bans" />
        [UsedImplicitly]
        public ListShadowBansResponse ListIPShadowBans(
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<ListShadowBansResponse>(
                Config.EndPointPaths.ShadowBans.ListIPBans,
                service,
                null,
                paginationOptions
            );
        }

        /// <summary>
        /// List all IP based Shadow Bans
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/list-ip-bans" />
        [UsedImplicitly]
        public async Task<ListShadowBansResponse> ListIPShadowBansAsync(
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<ListShadowBansResponse>(
                Config.EndPointPaths.ShadowBans.ListIPBans,
                service,
                null,
                paginationOptions
            );
        }

        /// <summary>
        /// List all Player ID based Shadow Bans
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/list-player-bans" />
        [UsedImplicitly]
        public ListShadowBansResponse ListPlayerShadowBans(
            PaginationOptions paginationOptions)
        {
            return Request.ExecuteSyncRequest<ListShadowBansResponse>(
                Config.EndPointPaths.ShadowBans.ListPlayerIDBans,
                service,
                null,
                paginationOptions
            );
        }

        /// <summary>
        /// List all Player ID based Shadow Bans
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/list-player-bans" />
        [UsedImplicitly]
        public async Task<ListShadowBansResponse> ListPlayerShadowBansAsync(
            PaginationOptions paginationOptions)
        {
            return await Request.ExecuteAsyncRequest<ListShadowBansResponse>(
                Config.EndPointPaths.ShadowBans.ListPlayerIDBans,
                service,
                null,
                paginationOptions
            );
        }
    }
}