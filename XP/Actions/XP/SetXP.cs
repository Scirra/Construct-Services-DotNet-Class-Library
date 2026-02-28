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
        public BaseResponse SetXP(ModifyXPOptions modifyXPOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.SetXPAPIPath,
                xpService,
                modifyXPOptions.BuildFormData()
            );
        }

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