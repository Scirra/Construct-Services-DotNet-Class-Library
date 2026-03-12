using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class XP
{        
    extension(XPService xpService)
    {
        /// <summary>
        /// Set a players XP
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/xp/set-xp" />
        [UsedImplicitly]
        public BaseResponse SetXP(Guid playerID, long amount)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.XP.Set,
                xpService,
                ModifyXPOptions.BuildFormData(playerID, amount)
            );
        }

        /// <summary>
        /// Set a players XP
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/xp/set-xp" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetXPAsync(Guid playerID, long amount)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.XP.Set,
                xpService,
                ModifyXPOptions.BuildFormData(playerID, amount)
            );
        }
    }
}