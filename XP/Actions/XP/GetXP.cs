using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using Guid = System.Guid;

namespace ConstructServices.XP.Actions;

public static partial class XP
{        
    private const string GetXPAPIPath = "/get.json";
    
    extension(XPService xpService)
    {
        /// <summary>
        /// Get XP for a specified player ID
        /// </summary>
        [UsedImplicitly]
        public XPResponse GetXP(Guid playerID)
        {
            var formData = new Dictionary<string, string>
            {
                {"playerID", playerID.ToString() }
            };
        
            return Request.ExecuteSyncRequest<XPResponse>(
                GetXPAPIPath,
                xpService,
                formData
            );
        }

        /// <summary>
        /// Get all channels in this game
        /// </summary>
        [UsedImplicitly]
        public async Task<XPResponse> GetXPAsync(Guid playerID)
        {
            var formData = new Dictionary<string, string>
            {
                {"playerID", playerID.ToString() }
            };
        
            return await Request.ExecuteAsyncRequest<XPResponse>(
                GetXPAPIPath,
                xpService,
                formData
            );
        }

        /// <summary>
        /// Get XP for currently authenticated player
        /// </summary>
        [UsedImplicitly]
        public XPResponse GetXP()
        {
            return Request.ExecuteSyncRequest<XPResponse>(
                GetXPAPIPath,
                xpService,
                []
            );
        }

        /// <summary>
        /// Get all channels in this game
        /// </summary>
        [UsedImplicitly]
        public async Task<XPResponse> GetXPAsync()
        {
            return await Request.ExecuteAsyncRequest<XPResponse>(
                GetXPAPIPath,
                xpService,
                []
            );
        }
    }
}