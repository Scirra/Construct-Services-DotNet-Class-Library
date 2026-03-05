using System;
using System.Collections.Generic;
using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    extension(XPServiceBase xpService)
    {
        /// <summary>Get a XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/get-bonus" />
        [UsedImplicitly]
        public BonusResponse GetBonus(Guid bonusID)
        {              
            return Request.ExecuteSyncRequest<BonusResponse>(
                Config.EndPointPaths.Bonuses.Get,
                xpService,
                GetBonusOptions.BuildFormData(bonusID)
            );
        }        
        
        /// <summary>Get a XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/get-bonus" />
        [UsedImplicitly]
        public async Task<BonusResponse> GetBonusAsync(Guid bonusID)
        {                    
            return await Request.ExecuteAsyncRequest<BonusResponse>(
                Config.EndPointPaths.Bonuses.Get,
                xpService,
                GetBonusOptions.BuildFormData(bonusID)
            );
        }
    }
    private static class GetBonusOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid bonusID)
        {
            var formData = new Dictionary<string, string>
            {
                { "bonusID", bonusID.ToString() }
            };
            return formData;
        }
    }
}