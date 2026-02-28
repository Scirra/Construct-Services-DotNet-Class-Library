using ConstructServices.Common;
using ConstructServices.XP.Objects;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class XP
{        
    extension(XPService xpService)
    {
        /// <summary>
        /// Get a players XP value, current rank and next rank
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/xp/get-xp" />
        [UsedImplicitly]
        public XPResponse GetXP(GetXPOptions getXPOptions)
        {
            return Request.ExecuteSyncRequest<XPResponse>(
                Config.GetXPAPIPath,
                xpService,
                getXPOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Get a players XP value, current rank and next rank
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/xp/get-xp" />
        [UsedImplicitly]
        public async Task<XPResponse> GetXPAsync(GetXPOptions getXPOptions)
        {
            return await Request.ExecuteAsyncRequest<XPResponse>(
                Config.GetXPAPIPath,
                xpService,
                getXPOptions.BuildFormData()
            );
        }
    }
}