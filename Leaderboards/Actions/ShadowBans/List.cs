using System.Threading.Tasks;
using ConstructServices.Common;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;

namespace ConstructServices.Leaderboards.Actions
{
    public static class List
    {
    
        extension(LeaderboardService service)
        {
            /// <summary>
            /// List all IP based Shadow Bans
            /// </summary>
            /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/list-ip-bans" />
            [UsedImplicitly]
            public GetShadowBansResponse ListIPShadowBans(
                PaginationOptions paginationOptions)
            {
                return Request.ExecuteSyncRequest<GetShadowBansResponse>(
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
            public async Task<GetShadowBansResponse> ListIPShadowBansAsync(
                PaginationOptions paginationOptions)
            {
                return await Request.ExecuteAsyncRequest<GetShadowBansResponse>(
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
            public GetShadowBansResponse ListPlayerShadowBans(
                PaginationOptions paginationOptions)
            {
                return Request.ExecuteSyncRequest<GetShadowBansResponse>(
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
            public async Task<GetShadowBansResponse> ListPlayerShadowBansAsync(
                PaginationOptions paginationOptions)
            {
                return await Request.ExecuteAsyncRequest<GetShadowBansResponse>(
                    Config.EndPointPaths.ShadowBans.ListPlayerIDBans,
                    service,
                    null,
                    paginationOptions
                );
            }
        }
    }
}
