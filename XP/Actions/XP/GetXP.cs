using ConstructServices.Common;
using ConstructServices.XP.Objects;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class XP
{        
    private const string GetXPAPIPath = "/get.json";
    
    extension(XPService xpService)
    {
        [UsedImplicitly]
        public XPResponse GetXP(GetXPOptions getXPOptions)
        {
            return Request.ExecuteSyncRequest<XPResponse>(
                GetXPAPIPath,
                xpService,
                getXPOptions.BuildFormData()
            );
        }

        [UsedImplicitly]
        public async Task<XPResponse> GetXPAsync(GetXPOptions getXPOptions)
        {
            return await Request.ExecuteAsyncRequest<XPResponse>(
                GetXPAPIPath,
                xpService,
                getXPOptions.BuildFormData()
            );
        }
    }
}