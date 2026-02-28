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
        public RankResponse UpdateRank(UpdateXPRankOptions updateOptions)
        {
            return Request.ExecuteSyncRequest<RankResponse>(
                Config.EditRankAPIPath,
                xpService,
                updateOptions.BuildFormData()
            );
        }

        [UsedImplicitly]
        public async Task<RankResponse> UpdateRankAsync(UpdateXPRankOptions updateOptions)
        {
            return await Request.ExecuteAsyncRequest<RankResponse>(
                Config.EditRankAPIPath,
                xpService,
                updateOptions.BuildFormData()
            );
        }
    }
}