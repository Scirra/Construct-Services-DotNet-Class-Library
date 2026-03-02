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
        public RankResponse DeleteRank(DeleteXPRankOptions deleteXPRankOptions)
        {
            return Request.ExecuteSyncRequest<RankResponse>(
                Config.EndPointPaths.Rankings.Delete,
                xpService,
                deleteXPRankOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Delete an existing XP Rank object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/delete-rank" />
        [UsedImplicitly]
        public async Task<RankResponse> DeleteRankAsync(DeleteXPRankOptions deleteXPRankOptions)
        {
            return await Request.ExecuteAsyncRequest<RankResponse>(
                Config.EndPointPaths.Rankings.Delete,
                xpService,
                deleteXPRankOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class DeleteXPRankOptions
    {
        private Guid RankID { get; }
    
        public DeleteXPRankOptions(string strRankID)
        {
            RankID = Guid.Parse(strRankID);
        }
        public DeleteXPRankOptions(Guid rankID)
        {
            RankID = rankID;
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "rankID", RankID.ToString() }
            };
            return formData;
        }
    }
}