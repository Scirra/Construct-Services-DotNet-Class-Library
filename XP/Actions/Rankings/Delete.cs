using System;
using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;
public static partial class Rankings
{        
    private const string DeleteRankAPIPath = "/deleterank.json";
    
    extension(XPService xpService)
    {        
        /// <summary>
        /// Delete an existing rank by its ID
        /// </summary>
        /// <param name="strRankID">The ID of the rank you want to delete.</param>
        [UsedImplicitly]
        public RankResponse Delete(string strRankID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strRankID);
            if (!idValidator.Successfull)
            {
                return new RankResponse(string.Format(idValidator.ErrorMessage, "Rank ID"));
            }
            return Delete(xpService, idValidator.ReturnedObject);
        }

        /// <summary>
        /// Delete an existing rank by its ID
        /// </summary>
        /// <param name="rankID">The ID of the rank you want to delete.</param>
        [UsedImplicitly]
        public RankResponse Delete(Guid rankID)
        {
            var formData = new Dictionary<string, string>
            {
                { "rankID", rankID.ToString() }
            };

            return Request.ExecuteSyncRequest<RankResponse>(
                DeleteRankAPIPath,
                xpService,
                formData
            );
        }

        /// <summary>
        /// Delete an existing rank by its ID
        /// </summary>
        /// <param name="strRankID">The ID of the rank you want to delete.</param>
        [UsedImplicitly]
        public async Task<RankResponse> DeleteAsync(string strRankID)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strRankID);
            if (!idValidator.Successfull)
            {
                return new RankResponse(string.Format(idValidator.ErrorMessage, "Rank ID"));
            }
            return await DeleteAsync(xpService, idValidator.ReturnedObject);
        }

        /// <summary>
        /// Delete an existing rank by its ID
        /// </summary>
        /// <param name="rankID">The ID of the rank you want to delete.</param>
        [UsedImplicitly]
        public async Task<RankResponse> DeleteAsync(Guid rankID)
        {
            var formData = new Dictionary<string, string>
            {
                { "rankID", rankID.ToString() }
            };

            return await Request.ExecuteAsyncRequest<RankResponse>(
                DeleteRankAPIPath,
                xpService,
                formData
            );
        }
    }
}