using ConstructServices.Common;
using ConstructServices.XP.Objects;
using JetBrains.Annotations;
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
        public BaseResponse SetXP(ModifyXPOptions modifyXPOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.SetXPAPIPath,
                xpService,
                modifyXPOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Set a players XP
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/xp/set-xp" />
        [UsedImplicitly]
        public async Task<BaseResponse> SetXPAsync(ModifyXPOptions modifyXPOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.SetXPAPIPath,
                xpService,
                modifyXPOptions.BuildFormData()
            );
        }
    }
}