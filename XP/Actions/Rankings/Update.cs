using ConstructServices.Common;
using ConstructServices.Common.Languages;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Functions = ConstructServices.Common.Validations.Common.Functions;

namespace ConstructServices.XP.Actions;

public static partial class Rankings
{        
    extension(XPService xpService)
    {
        /// <summary>
        /// Edit an existing XP Rank object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/update-rank" />
        [UsedImplicitly]
        public RankResponse UpdateRank(Guid rankID, UpdateXPRankOptions updateOptions)
        {
            var validation = updateOptions.Validate();
            if (!validation.Valid) return new RankResponse(validation.ErrorMessage);

            return Request.ExecuteSyncRequest<RankResponse>(
                Config.EndPointPaths.Rankings.Update,
                xpService,
                updateOptions.BuildFormData(rankID)
            );
        }

        /// <summary>
        /// Edit an existing XP Rank object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/update-rank" />
        [UsedImplicitly]
        public async Task<RankResponse> UpdateRankAsync(Guid rankID, UpdateXPRankOptions updateOptions)
        {
            var validation = updateOptions.Validate();
            if (!validation.Valid) return new RankResponse(validation.ErrorMessage);

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
        public long? AtXP { private get; set; }

        [UsedImplicitly]
        public string Title { private get; set; }

        [UsedImplicitly]
        public string Description { private get; set; }
        
        [UsedImplicitly]
        public string LanguageISO { private get; set; }

        [UsedImplicitly]
        public SourceLanguage Language {
            set => LanguageISO = value.ISO();
        }
        internal Common.Validations.Responses.ValidationResponseBase Validate()
        {
            var languageValidation = Functions.IsSourceLanguageISOValid(LanguageISO, true);
            if (!languageValidation.Valid) return languageValidation;

            return new Common.Validations.Responses.SuccessfullValidation();
        }

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