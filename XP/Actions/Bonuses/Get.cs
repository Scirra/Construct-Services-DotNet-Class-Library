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
        /// <summary>Get a XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/get-bonus" />
        [UsedImplicitly]
        public BonusResponse GetBonus(GetBonusOptions getBonusOptions)
        {              
            return Request.ExecuteSyncRequest<BonusResponse>(
                Config.GetBonusAPIPath,
                xpService,
                getBonusOptions.BuildFormData()
            );
        }        
        
        /// <summary>Get a XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/get-bonus" />
        [UsedImplicitly]
        public async Task<BonusResponse> GetBonusAsync(GetBonusOptions getBonusOptions)
        {                    
            return await Request.ExecuteAsyncRequest<BonusResponse>(
                Config.GetBonusAPIPath,
                xpService,
                getBonusOptions.BuildFormData()
            );
        }

        /// <summary>Retrieve all XP Bonus objects between date ranges</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/list-bonuses" />
        [UsedImplicitly]
        public BonusesResponse GetBonuses(GetBonusesOptions getBonusesOptions)
        {              
            return Request.ExecuteSyncRequest<BonusesResponse>(
                Config.ListBonusesAPIPath,
                xpService,
                getBonusesOptions.BuildFormData()
            );
        }        
        
        /// <summary>Retrieve all XP Bonus objects between date ranges</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/list-bonuses" />
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