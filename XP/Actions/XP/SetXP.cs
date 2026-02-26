using System;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class XP
{        
    private const string SetXPAPIPath = "/setxp.json";
    
    extension(XPService xpService)
    {
        /// <summary>
        /// Set XP for a specified player ID
        /// </summary>
        [UsedImplicitly]
        public BaseResponse SetXP(Guid playerID, long xp)
        {
            var formData = new Dictionary<string, string>
            {
                {"playerID", playerID.ToString() },
                {"xp", xp.ToString() }
            };
        
            return Request.ExecuteSyncRequest<BaseResponse>(
                SetXPAPIPath,
                xpService,
                formData
            );
        }

        /// <summary>
        /// Set XP for a specified player ID
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> SetXPAsync(Guid playerID, long xp)
        {
            var formData = new Dictionary<string, string>
            {
                {"playerID", playerID.ToString() },
                {"xp", xp.ToString() }
            };
        
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                SetXPAPIPath,
                xpService,
                formData
            );
        }
    }
}