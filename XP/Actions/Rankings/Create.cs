using ConstructServices.Common;
using ConstructServices.Common.Languages;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Collections.Generic;
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
    public sealed class CreateXPRankOptions
    {    
        [UsedImplicitly]
        public string Title { private get; set; }

        [UsedImplicitly]
        public string Description { private get; set; }

        [UsedImplicitly]
        public string LanguageISO {
            private get;
            set
            {
                if (!Validations.IsValidSourceLanguage(value))
                    throw new InvalidSourceLanguageException();
                field = value;
            }
        }

        [UsedImplicitly]
        public SourceLanguage Language {
            set => LanguageISO = value.ISO();
        }

        [UsedImplicitly]
        public long AtXP { private get; set; }

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