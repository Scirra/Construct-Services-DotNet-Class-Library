using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public BaseResponse DeleteBonus(string strBonusID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strBonusID);
            if (!idValidator.Successfull)
            {
                return new RankResponse(string.Format(idValidator.ErrorMessage, "Bonus ID"));
            }
            return xpService.DeleteBonus(idValidator.ReturnedObject);
        }

        /// <summary>
        /// Delete an existing bonus by ID
        /// </summary>
        [UsedImplicitly]
        public BaseResponse DeleteBonus(
            Guid bonusID)
        {            
            var formData = new Dictionary<string, string>
            {
                { "bonusID", bonusID.ToString() }
            };

            return Request.ExecuteSyncRequest<BaseResponse>(
                DeleteBonusAPIPath,
                xpService,
                formData
            );
        }

        /// <summary>
        /// Delete an existing bonus by ID
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteBonusAsync(string strBonusID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strBonusID);
            if (!idValidator.Successfull)
            {
                return new BaseResponse(string.Format(idValidator.ErrorMessage, "Bonus ID"));
            }
            return await xpService.DeleteBonusAsync(idValidator.ReturnedObject);
        }

        /// <summary>
        /// Delete an existing bonus by ID
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> DeleteBonusAsync(
            Guid id)
        {            
            var formData = new Dictionary<string, string>
            {
                { "bonusID", id.ToString() }
            };

            return await Request.ExecuteAsyncRequest<BaseResponse>(
                DeleteBonusAPIPath,
                xpService,
                formData
            );
        }
    }
}
