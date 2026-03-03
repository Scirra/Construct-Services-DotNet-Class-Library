using System;
using System.Collections.Generic;
using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;
public static partial class Rankings
{        
    extension(XPService xpService)
    {        
        /// <summary>
        /// Delete an existing XP Rank object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/delete-rank" />
        [UsedImplicitly]
        public RankResponse DeleteRank(Guid rankID)
        {
            return Request.ExecuteSyncRequest<RankResponse>(
                Config.EndPointPaths.Rankings.Delete,
                xpService,
                DeleteXPRankOptions.BuildFormData(rankID)
            );
        }

        /// <summary>
        /// Delete an existing XP Rank object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/delete-rank" />
        [UsedImplicitly]
        public async Task<RankResponse> DeleteRankAsync(Guid rankID)
        {
            return await Request.ExecuteAsyncRequest<RankResponse>(
                Config.EndPointPaths.Rankings.Delete,
                xpService,
                DeleteXPRankOptions.BuildFormData(rankID)
            );
        }
    }

    private static class DeleteXPRankOptions
    {
        internal static Dictionary<string, string> BuildFormData(Guid rankID)
        {
            var formData = new Dictionary<string, string>
            {
                { "rankID", rankID.ToString() }
            };
            return formData;
        }
    }
}