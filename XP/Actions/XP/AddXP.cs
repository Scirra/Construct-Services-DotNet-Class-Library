using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.XP.Objects;

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
        public BaseResponse AddXP(ModifyXPOptions modifyXPOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.AddXPAPIPath,
                xpService,
                modifyXPOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Add XP to a player
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/xp/add-xp" />
        [UsedImplicitly]
        public async Task<BaseResponse> AddXPAsync(ModifyXPOptions modifyXPOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.AddXPAPIPath,
                xpService,
                modifyXPOptions.BuildFormData()
            );
        }
    }
}
