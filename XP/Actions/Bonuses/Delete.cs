using ConstructServices.Common;
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
        public BaseResponse DeleteBonus(
            Guid id)
        {            
            var formData = new Dictionary<string, string>
            {
                { "bonusID", id.ToString() }
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
