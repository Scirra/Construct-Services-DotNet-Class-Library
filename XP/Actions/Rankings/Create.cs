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
        public RankResponse CreateRank(CreateXPRankOptions createXPRankOptions)
        {
            return Request.ExecuteSyncRequest<RankResponse>(
                Config.CreateRankAPIPath,
                xpService,
                createXPRankOptions.BuildFormData()
            );
        }

        [UsedImplicitly]
        public async Task<RankResponse> CreateRankAsync(CreateXPRankOptions createXPRankOptions)
        {
            return await Request.ExecuteAsyncRequest<RankResponse>(
                Config.CreateRankAPIPath,
                xpService,
                createXPRankOptions.BuildFormData()
            );
        }
    }
}