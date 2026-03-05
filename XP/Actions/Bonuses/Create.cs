using ConstructServices.Common;
using ConstructServices.Common.Languages;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Functions = ConstructServices.Common.Validations.Common.Functions;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    extension(XPService xpService)
    {
        /// <summary>
        /// Creates a new XP Bonus object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/create-bonus" />
        [UsedImplicitly]
        public BonusResponse CreateBonus(CreateXPBonusOptions createXPBonusOptions)
        {
            var validation = createXPBonusOptions.Validate();
            if (!validation.Valid) return new BonusResponse(validation.ErrorMessage);

            return Request.ExecuteSyncRequest<BonusResponse>(
                Config.EndPointPaths.Bonuses.Create,
                xpService,
                createXPBonusOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Creates a new XP Bonus object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/create-bonus" />
        [UsedImplicitly]
        public async Task<BonusResponse> CreateBonusAsync(CreateXPBonusOptions createXPBonusOptions)
        {
            var validation = createXPBonusOptions.Validate();
            if (!validation.Valid) return new BonusResponse(validation.ErrorMessage);

            return await Request.ExecuteAsyncRequest<BonusResponse>(
                Config.EndPointPaths.Bonuses.Create,
                xpService,
                createXPBonusOptions.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class CreateXPBonusOptions
    {
        [UsedImplicitly]
        public DateTime Start { private get; set; } 

        [UsedImplicitly]
        public DateTime End { private get; set; } 

        [UsedImplicitly]
        public decimal Modifier { private get; set; } 

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
            var modifierValidation = Common.Validations.XP.Functions.IsBonusModifierValid(Modifier);
            if (!modifierValidation.Valid) return modifierValidation;

            var titleValidation = Common.Validations.XP.Functions.IsBonusTitleValid(Title);
            if (!titleValidation.Valid) return titleValidation;

            var descriptionValidation = Common.Validations.XP.Functions.IsBonusDescriptionValid(Title);
            if (!descriptionValidation.Valid) return descriptionValidation;

            var languageValidation = Functions.IsSourceLanguageISOValid(LanguageISO, true);
            if (!languageValidation.Valid) return languageValidation;

            return new Common.Validations.Responses.SuccessfullValidation();
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "start", new DateTimeOffset(Start).ToUnixTimeSeconds().ToString() },
                { "end", new DateTimeOffset(End).ToUnixTimeSeconds().ToString() },
                { "title", Title },
                { "description", Description },
                { "language", LanguageISO },
                { "modifier", Modifier.ToString(CultureInfo.InvariantCulture) }
            };
            return formData;
        }
    }
}