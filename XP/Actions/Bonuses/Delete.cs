using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.XP.Objects;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{

    extension(XPService xpService)
    {        
        /// <summary>
        /// Delete an existing bonus by ID
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteBonus(DeleteXPBonusOptions deleteXPBonusOptions)
        {            
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.DeleteBonusAPIPath,
                xpService,
                deleteXPBonusOptions.BuildFormData()
            );
        }

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
