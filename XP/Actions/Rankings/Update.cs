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
        public RankResponse UpdateRank(UpdateXPRankOptions updateOptions)
        {
            return Request.ExecuteSyncRequest<RankResponse>(
                Config.EndPointPaths.Rankings.Update,
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
                Config.EndPointPaths.Rankings.Update,
                xpService,
                updateOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class UpdateXPRankOptions
    {
        private Guid ID { get; }

        [UsedImplicitly]
        public long? AtXP { get; set; }

        [UsedImplicitly]
        public string Title { get; set; }

        [UsedImplicitly]
        public string Description { get; set; }

        [UsedImplicitly]
        public string LanguageISO { get; set; }
        public UpdateXPRankOptions(Guid rankID)
        {
            ID = rankID;
        }
        public UpdateXPRankOptions(string strRankID)
        {
            ID = Guid.Parse(strRankID);
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "title", Title },
                { "description", Description },
                { "language", LanguageISO },
                { "rankID", ID.ToString() }
            };
            if(AtXP.HasValue) formData.Add("xp", AtXP.Value.ToString());
            return formData;
        }
    }
}