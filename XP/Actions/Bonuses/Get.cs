using ConstructServices.Common;
using ConstructServices.XP.Objects;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    extension(XPService xpService)
    {
        [UsedImplicitly]
        public BonusResponse GetBonus(GetBonusOptions getBonusOptions)
        {              
            return Request.ExecuteSyncRequest<BonusResponse>(
                Config.GetBonusAPIPath,
                xpService,
                getBonusOptions.BuildFormData()
            );
        }        
        
        [UsedImplicitly]
        public async Task<BonusResponse> GetBonusAsync(GetBonusOptions getBonusOptions)
        {                    
            return await Request.ExecuteAsyncRequest<BonusResponse>(
                Config.GetBonusAPIPath,
                xpService,
                getBonusOptions.BuildFormData()
            );
        }

        [UsedImplicitly]
        public BonusesResponse GetBonuses(GetBonusesOptions getBonusesOptions)
        {              
            return Request.ExecuteSyncRequest<BonusesResponse>(
                Config.ListBonusesAPIPath,
                xpService,
                getBonusesOptions.BuildFormData()
            );
        }        
        
        [UsedImplicitly]
        public async Task<BonusesResponse> GetBonusesAsync(GetBonusesOptions getBonusesOptions)
        {                    
            return await Request.ExecuteAsyncRequest<BonusesResponse>(
                Config.ListBonusesAPIPath,
                xpService,
                getBonusesOptions.BuildFormData()
            );
        }
    }
}