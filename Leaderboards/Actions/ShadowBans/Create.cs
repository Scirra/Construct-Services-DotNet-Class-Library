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
        /// Create a new Shadow Ban
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/create-shadow-ban" />
        [UsedImplicitly]
        public ShadowBanResponse BanIPHash(CreateShadowBanBase createShadowBanOptions)
        {
            return Request.ExecuteSyncRequest<ShadowBanResponse>(
                Config.EndPointPaths.ShadowBans.Create,
                service,
                createShadowBanOptions.BuildFormData()
            );
        }
        
        /// <summary>
        /// Create a new Shadow Ban
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/leaderboards/api-end-points/shadow-bans/create-shadow-ban" />
        [UsedImplicitly]
        public async Task<ShadowBanResponse> BanIPHashAsync(CreateShadowBanBase createShadowBanOptions)
        {
            return await Request.ExecuteAsyncRequest<ShadowBanResponse>(
                Config.EndPointPaths.ShadowBans.Create,
                service,
                createShadowBanOptions.BuildFormData()
            );
        }
    }
}