using ConstructServices.Common;
using ConstructServices.XP.Objects;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;
public static partial class Rankings
{        
    extension(XPService xpService)
    {        
        [UsedImplicitly]
        public RankResponse DeleteRank(DeleteXPRankOptions deleteXPRankOptions)
        {
            return Request.ExecuteSyncRequest<RankResponse>(
                Config.DeleteRankAPIPath,
                xpService,
                deleteXPRankOptions.BuildFormData()
            );
        }

        [UsedImplicitly]
        public async Task<RankResponse> DeleteRankAsync(DeleteXPRankOptions deleteXPRankOptions)
        {
            return await Request.ExecuteAsyncRequest<RankResponse>(
                Config.DeleteRankAPIPath,
                xpService,
                deleteXPRankOptions.BuildFormData()
            );
        }
    }
}