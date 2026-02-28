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
        /// <summary>
        /// Edit an existing XP Rank object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/edit-rank" />
        [UsedImplicitly]
        public RankResponse UpdateRank(UpdateXPRankOptions updateOptions)
        {
            return Request.ExecuteSyncRequest<RankResponse>(
                Config.EditRankAPIPath,
                xpService,
                updateOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Edit an existing XP Rank object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/edit-rank" />
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