using ConstructServices.Common;
using ConstructServices.XP.Objects;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class XP
{        
    
    extension(XPService xpService)
    {
        [UsedImplicitly]
        public BaseResponse RemoveXP(ModifyXPOptions modifyXPOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.RemoveXPAPIPath,
                xpService,
                modifyXPOptions.BuildFormData()
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> RemoveXPAsync(ModifyXPOptions modifyXPOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.RemoveXPAPIPath,
                xpService,
                modifyXPOptions.BuildFormData()
            );
        }
    }
}