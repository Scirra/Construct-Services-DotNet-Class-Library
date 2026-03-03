using System;
using System.Collections.Generic;
using ConstructServices.Common;
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
        public XPResponse GetXP(Guid playerID, GetXPOptions getXPOptions = null)
        {
            return Request.ExecuteSyncRequest<XPResponse>(
                Config.EndPointPaths.XP.Get,
                xpService,
                GetXPOptions.BuildFormData(playerID)
            );
        }

        /// <summary>
        /// Get a players XP value, current rank and next rank
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/xp/get-xp" />
        [UsedImplicitly]
        public async Task<XPResponse> GetXPAsync(Guid playerID, GetXPOptions getXPOptions = null)
        {
            return await Request.ExecuteAsyncRequest<XPResponse>(
                Config.EndPointPaths.XP.Get,
                xpService,
                GetXPOptions.BuildFormData(playerID)
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class GetXPOptions
    { 
        internal static Dictionary<string, string> BuildFormData(Guid playerID)
        {
            var formData = new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() }
            };
            return formData;
        }
    }
}