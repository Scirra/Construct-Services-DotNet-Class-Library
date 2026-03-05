using System;
using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    extension(XPService xpService)
    {        
        /// <summary>Deletes an existing XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/delete-bonus" />
        [UsedImplicitly]
        public BaseResponse DeleteBonus(Guid bonusID)
        {            
            return Request.ExecuteSyncRequest<BaseResponse>(
                Config.EndPointPaths.Bonuses.Delete,
                xpService,
                DeleteXPBonusOptions.BuildFormData(bonusID)
            );
        }

        /// <summary>Deletes an existing XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/delete-bonus" />
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteBonusAsync(Guid bonusID)
        {       
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                Config.EndPointPaths.Bonuses.Delete,
                xpService,
                DeleteXPBonusOptions.BuildFormData(bonusID)
            );
        }
    }
    private static class DeleteXPBonusOptions
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
