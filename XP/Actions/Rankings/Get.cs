using System.Threading.Tasks;
using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;

namespace ConstructServices.XP.Actions;
public static partial class Rankings
{        
    extension(XPService xpService)
    {
        /// <summary>
        /// List all existing XP Rank objects
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/list-ranks" />
        [UsedImplicitly]
        public RanksResponse ListAllRanks()
        {
            return Request.ExecuteSyncRequest<RanksResponse>(
                Config.GetRanksAPIPath,
                xpService,
                []
            );
        }

        /// <summary>
        /// List all existing XP Rank objects
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/list-ranks" />
        [UsedImplicitly]
        public async Task<RanksResponse> ListAllRanksAsync()
        {
            return await Request.ExecuteAsyncRequest<RanksResponse>(
                Config.GetRanksAPIPath,
                xpService,
                []
            );
        }
    }
}