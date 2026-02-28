using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.XP.Objects;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{

    extension(XPService xpService)
    {        
        /// <summary>Deletes an existing XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/delete-bonus" />
        [UsedImplicitly]
        public BaseResponse DeleteBonus(DeleteXPBonusOptions deleteXPBonusOptions)
        {            
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.DeleteBonusAPIPath,
                xpService,
                deleteXPBonusOptions.BuildFormData()
            );
        }

        /// <summary>Deletes an existing XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/delete-bonus" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteBonusAsync(DeleteXPBonusOptions deleteXPBonusOptions)
        {       
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.DeleteBonusAPIPath,
                xpService,
                deleteXPBonusOptions.BuildFormData()
            );
        }
    }
}
