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
        public XPResponse GetXP(GetXPOptions getXPOptions)
        {
            return Request.ExecuteSyncRequest<XPResponse>(
                Config.EndPointPaths.XP.Get,
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
                Config.EndPointPaths.XP.Get,
                xpService,
                getXPOptions.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class GetXPOptions
    { 
        private Guid PlayerID { get; }

        /// <summary>
        /// No player ID specified, uses currently authenticated player
        /// </summary>
        public GetXPOptions()
        {
        }

        public GetXPOptions(string strPlayerID)
        {
            PlayerID = Guid.Parse(strPlayerID);
        }
        public GetXPOptions(Guid playerID)
        {
            PlayerID = playerID;
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>();
            if (PlayerID != Guid.Empty)
            {
                formData.Add("playerID", PlayerID.ToString());
            }
            return formData;
        }
    }
}