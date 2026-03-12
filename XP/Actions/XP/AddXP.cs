using System;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;
public static partial class XP
{        
    extension(XPService xpService)
    {
        /// <summary>
        /// Add XP to a player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/xp/add-xp" />
        [UsedImplicitly]
        public BaseResponse AddXP(Guid playerID, long addAmount)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.XP.Add,
                xpService,
                ModifyXPOptions.BuildFormData(playerID, addAmount)
            );
        }

        /// <summary>
        /// Add XP to a player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/xp/add-xp" />
        [UsedImplicitly]
        public async Task<BaseResponse> AddXPAsync(Guid playerID, long addAmount)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.XP.Add,
                xpService,
                ModifyXPOptions.BuildFormData(playerID, addAmount)
            );
        }
    }
}
