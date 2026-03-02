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
        /// Edit an existing XP Rank object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/edit-rank" />
        [UsedImplicitly]
        public RankResponse UpdateRank(Guid rankID, UpdateXPRankOptions updateOptions)
        {
            return Request.ExecuteSyncRequest<RankResponse>(
                Config.EndPointPaths.Rankings.Update,
                xpService,
                updateOptions.BuildFormData(rankID)
            );
        }

        /// <summary>
        /// Edit an existing XP Rank object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/edit-rank" />
        [UsedImplicitly]
        public async Task<RankResponse> UpdateRankAsync(Guid rankID, UpdateXPRankOptions updateOptions)
        {
            return await Request.ExecuteAsyncRequest<RankResponse>(
                Config.EndPointPaths.Rankings.Update,
                xpService,
                updateOptions.BuildFormData(rankID)
            );
        }
    }

    [UsedImplicitly]
    public sealed class UpdateXPRankOptions
    {

        [UsedImplicitly]
        public long? AtXP { get; set; }

        [UsedImplicitly]
        public string Title { get; set; }

        [UsedImplicitly]
        public string Description { get; set; }

        [UsedImplicitly]
        public string LanguageISO { get; set; }

        internal Dictionary<string, string> BuildFormData(Guid rankID)
        {
            var formData = new Dictionary<string, string>
            {
                { "title", Title },
                { "description", Description },
                { "language", LanguageISO },
                { "rankID", rankID.ToString() }
            };
            if(AtXP.HasValue) formData.Add("xp", AtXP.Value.ToString());
            return formData;
        }
    }
}