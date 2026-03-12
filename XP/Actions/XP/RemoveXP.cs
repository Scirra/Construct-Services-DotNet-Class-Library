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
        /// Remove XP from a player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/xp/remove-xp" />
        [UsedImplicitly]
        public BaseResponse RemoveXP(Guid playerID, long amount)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.XP.Remove,
                xpService,
                ModifyXPOptions.BuildFormData(playerID, amount)
            );
        }

        /// <summary>
        /// Remove XP from a player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/xp/remove-xp" />
        [UsedImplicitly]
        public async Task<BaseResponse> RemoveXPAsync(Guid playerID, long amount)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.XP.Remove,
                xpService,
                ModifyXPOptions.BuildFormData(playerID, amount)
            );
        }
    }
}