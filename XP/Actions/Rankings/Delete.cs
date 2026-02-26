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
        /// <param name="id">The ID of the rank you want to delete.</param>
        [UsedImplicitly]
        public RankResponse Delete(Guid id)
        {
            var formData = new Dictionary<string, string>
            {
                { "rankID", id.ToString() }
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
        /// <param name="id">The ID of the rank you want to delete.</param>
        [UsedImplicitly]
        public async Task<RankResponse> DeleteAsync(Guid id)
        {
            var formData = new Dictionary<string, string>
            {
                { "rankID", id.ToString() }
            };

            return await Request.ExecuteAsyncRequest<RankResponse>(
                DeleteRankAPIPath,
                xpService,
                formData
            );
        }
    }
}