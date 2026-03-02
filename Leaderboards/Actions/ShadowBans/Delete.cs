using ConstructServices.Common;
using ConstructServices.Leaderboards.Objects;
using ConstructServices.Leaderboards.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.Leaderboards.Actions;

public static partial class ShadowBans
{
    extension(LeaderboardService service)
    {
        /// <summary>
        /// Delete a Shadow Ban
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/remove-shadow-ban" />
        [UsedImplicitly]
        public ShadowBanResponse UnbanIPHash(DeleteShadowBanBase deleteShadowBanOptions)
        {
            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                Config.EndPointPaths.ShadowBans.Delete,
                service,
                deleteShadowBanOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Delete a Shadow Ban
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/remove-shadow-ban" />
        [UsedImplicitly]
        public async Task<ShadowBanResponse> UnbanIPHashAsync(DeleteShadowBanBase deleteShadowBanOptions)
        {
            return await Request.ExecuteAsyncRequest<ShadowBanResponse>(
                Config.EndPointPaths.ShadowBans.Delete,
                service,
                deleteShadowBanOptions.BuildFormData()
            );
        }
    }
}