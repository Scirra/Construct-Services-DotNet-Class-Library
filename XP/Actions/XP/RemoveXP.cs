using System;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class XP
{        
    private const string RemoveXPAPIPath = "/removexp.json";
    
    extension(XPService xpService)
    {
        /// <summary>
        /// Remove XP from a specified player ID
        /// </summary>
        [UsedImplicitly]
        public BaseResponse RemoveXP(Guid playerID, long xp)
        {
            var formData = new Dictionary<string, string>
            {
                {"playerID", playerID.ToString() },
                {"xp", xp.ToString() }
            };
        
            return Request.ExecuteSyncRequest<BaseResponse>(
                RemoveXPAPIPath,
                xpService,
                formData
            );
        }

        /// <summary>
        /// Remove XP from a specified player ID
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> RemoveXPAsync(Guid playerID, long xp)
        {
            var formData = new Dictionary<string, string>
            {
                {"playerID", playerID.ToString() },
                {"xp", xp.ToString() }
            };
        
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                RemoveXPAPIPath,
                xpService,
                formData
            );
        }
    }
}