using System;
using System.Collections.Generic;
using ConstructServices.Common;
using ConstructServices.XP.Objects;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    private const string ListBonusesAPIPath = "/listbonuses.json";
    private const string GetBonusAPIPath = "/getbonus.json";

    extension(XPService xpService)
    {
        [UsedImplicitly]
        public BonusesResponse GetBonus(GetBonusOptions getBonusOptions)
        {              
            return Request.ExecuteSyncRequest<BonusesResponse>(
                GetBonusAPIPath,
                xpService,
                getBonusOptions.BuildFormData()
            );
        }        
        
        [UsedImplicitly]
        public async Task<BonusesResponse> GetBonusAsync(GetBonusOptions getBonusOptions)
        {                    
            return await Request.ExecuteAsyncRequest<BonusesResponse>(
                GetBonusAPIPath,
                xpService,
                getBonusOptions.BuildFormData()
            );
        }

        [UsedImplicitly]
        public BonusesResponse GetBonuses(GetBonusesOptions getBonusesOptions)
        {              
            return Request.ExecuteSyncRequest<BonusesResponse>(
                ListBonusesAPIPath,
                xpService,
                getBonusesOptions.BuildFormData()
            );
        }        
        
        [UsedImplicitly]
        public async Task<BonusesResponse> GetBonusesAsync(GetBonusesOptions getBonusesOptions)
        {                    
            return await Request.ExecuteAsyncRequest<BonusesResponse>(
                ListBonusesAPIPath,
                xpService,
                getBonusesOptions.BuildFormData()
            );
        }
    }
}