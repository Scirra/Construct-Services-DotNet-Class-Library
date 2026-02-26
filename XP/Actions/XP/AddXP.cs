using System;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class XP
{        
    private const string AddXPAPIPath = "/addxp.json";
    
    extension(XPService xpService)
    {
        /// <summary>
        /// Add XP to a specified player ID
        /// </summary>
        [UsedImplicitly]
        public BaseResponse AddXP(Guid playerID, long xp)
        {
            var formData = new Dictionary<string, string>
            {
                {"playerID", playerID.ToString() },
                {"xp", xp.ToString() }
            };
        
            return Request.ExecuteSyncRequest<BaseResponse>(
                AddXPAPIPath,
                xpService,
                formData
            );
        }

        /// <summary>
        /// Add XP to a specified player ID
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> AddXPAsync(Guid playerID, long xp)
        {
            var formData = new Dictionary<string, string>
            {
                {"playerID", playerID.ToString() },
                {"xp", xp.ToString() }
            };
        
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                AddXPAPIPath,
                xpService,
                formData
            );
        }
    }
}
