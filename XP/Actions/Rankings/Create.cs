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
        /// Creates a new XP Rank object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/create-rank" />
        [UsedImplicitly]
        public RankResponse CreateRank(CreateXPRankOptions createXPRankOptions)
        {
            return Request.ExecuteSyncRequest<RankResponse>(
                Config.EndPointPaths.Rankings.Create,
                xpService,
                createXPRankOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Creates a new XP Rank object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/create-rank" />
        [UsedImplicitly]
        public async Task<RankResponse> CreateRankAsync(CreateXPRankOptions createXPRankOptions)
        {
            return await Request.ExecuteAsyncRequest<RankResponse>(
                Config.EndPointPaths.Rankings.Create,
                xpService,
                createXPRankOptions.BuildFormData()
            );
        }
    }

    [UsedImplicitly]
    public sealed class CreateXPRankOptions(long strAtXp, string title, string description = null, string languageISO = null)
    {    
        private string Title { get; } = title;
        private string Description { get; } = description;

        [UsedImplicitly]
        public string LanguageISO { private get; set; } = languageISO;

        [UsedImplicitly]
        public long AtXP { private get; set; } = strAtXp;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "title", Title },
                { "description", Description },
                { "language", LanguageISO },
                { "xp", AtXP.ToString() }
            };
            return formData;
        }
    }
}