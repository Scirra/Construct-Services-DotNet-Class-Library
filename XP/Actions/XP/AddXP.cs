using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.XP.Objects;

namespace ConstructServices.XP.Actions;

public static partial class XP
{        
    private const string AddXPAPIPath = "/addxp.json";
    
    extension(XPService xpService)
    {
        [UsedImplicitly]
        public BaseResponse AddXP(ModifyXPOptions modifyXPOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                AddXPAPIPath,
                xpService,
                modifyXPOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Add XP to a specified player ID
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> AddXPAsync(ModifyXPOptions modifyXPOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                AddXPAPIPath,
                xpService,
                modifyXPOptions.BuildFormData()
            );
        }
    }
}
