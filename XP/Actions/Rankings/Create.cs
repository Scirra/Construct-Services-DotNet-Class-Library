using ConstructServices.Common;
using ConstructServices.Common.Languages;
using ConstructServices.Common.Validations.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Functions = ConstructServices.Common.Validations.Common.Functions;

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
            var validation = createXPRankOptions.Validate();
            if (!validation.Valid) return new RankResponse(validation.ErrorMessage);

            return Request.ExecuteMultiPartFormSyncRequest<RankResponse>(
                Config.EndPointPaths.Rankings.Create,
                xpService,
                createXPRankOptions.BuildFormData(),
                createXPRankOptions.BuildBinaryFormData()
            );
        }

        /// <summary>
        /// Creates a new XP Rank object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/ranks/create-rank" />
        [UsedImplicitly]
        public async Task<RankResponse> CreateRankAsync(CreateXPRankOptions createXPRankOptions)
        {
            var validation = createXPRankOptions.Validate();
            if (!validation.Valid) return new RankResponse(validation.ErrorMessage);

            return await Request.ExecuteMultiPartFormAsyncRequest<RankResponse>(
                Config.EndPointPaths.Rankings.Create,
                xpService,
                createXPRankOptions.BuildFormData(),
                createXPRankOptions.BuildBinaryFormData()
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
        public string LanguageISO { private get; set; }

        [UsedImplicitly]
        public SourceLanguage Language {
            set => LanguageISO = value.ISO();
        }

        [UsedImplicitly]
        public long AtXP { private get; set; }
        internal Common.Validations.Responses.ValidationResponseBase Validate()
        {
            var titleValidation = Common.Validations.XP.Functions.IsRankTitleValid(Title);
            if (!titleValidation.Valid) return titleValidation;

            var descriptionValidation = Common.Validations.XP.Functions.IsRankTitleValid(Description);
            if (!descriptionValidation.Valid) return descriptionValidation;

            var languageValidation = Functions.IsSourceLanguageISOValid(LanguageISO, true);
            if (!languageValidation.Valid) return languageValidation;

            if (Logo != null)
            {
                var logoValidation = Logo.IsPictureValid();
                if (!logoValidation.Valid) return logoValidation;
            }

            return new Common.Validations.Responses.SuccessfullValidation();
        }
        
        [UsedImplicitly]
        public PictureData Logo { private get; set; }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "title", Title },
                { "description", Description },
                { "language", LanguageISO },
                { "xp", AtXP.ToString() }
            };
            if (Logo != null)
            {
                if (!string.IsNullOrWhiteSpace(Logo.Base64))
                {
                    formData.Add("logo", Logo.Base64);
                }
                else if (Logo.URL != null)
                {
                    formData.Add("logoURL", Logo.URL.ToString());
                }
            }
            return formData;
        }

        internal Dictionary<string, ByteArrayContent> BuildBinaryFormData()
        {
            var postedBinaryData = new Dictionary<string, ByteArrayContent>();
            if (Logo?.Bytes != null)
            {
                postedBinaryData.Add("logoData", new ByteArrayContent(Logo.Bytes));
            }
            return postedBinaryData;
        }
    }
}