using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.XP.Objects;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    private const string DeleteBonusAPIPath = "/deletebonus.json";

    extension(XPService xpService)
    {        
        /// <summary>
        /// Delete an existing bonus by ID
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteBonus(DeleteXPBonusOptions deleteXPBonusOptions)
        {            
            return Request.ExecuteSyncRequest<BaseResponse>(
                DeleteBonusAPIPath,
                xpService,
                deleteXPBonusOptions.BuildFormData()
            );
        }

        [UsedImplicitly]
        public async Task<BaseResponse> DeleteBonusAsync(DeleteXPBonusOptions deleteXPBonusOptions)
        {       
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                DeleteBonusAPIPath,
                xpService,
                deleteXPBonusOptions.BuildFormData()
            );
        }
    }
}
