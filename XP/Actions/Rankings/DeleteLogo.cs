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
        /// Delete a logo for an XP rank
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/delete-logo" />
        [UsedImplicitly]
        public RankResponse DeleteRankLogo(Guid rankID)
        {
            return Request.ExecuteSyncRequest<RankResponse>(
                Config.EndPointPaths.Rankings.DeleteLogo,
                xpService,
                DeleteXPRankLogoOptions.BuildFormData(rankID)
            );
        }

        /// <summary>
        /// Delete a logo for an XP rank
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/delete-logo" />
        [UsedImplicitly]
        public async Task<RankResponse> DeleteRankLogoAsync(Guid rankID)
        {
            return await Request.ExecuteAsyncRequest<RankResponse>(
                Config.EndPointPaths.Rankings.DeleteLogo,
                xpService,
                DeleteXPRankLogoOptions.BuildFormData(rankID)
            );
        }
    }

    private static class DeleteXPRankLogoOptions
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