using ConstructServices.Common;
using ConstructServices.Common.Languages;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;
public static partial class Bonuses
{
    extension(XPService xpService)
    {
        /// <summary>Update an existing XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/update-bonus" />
        [UsedImplicitly]
        public BonusResponse UpdateBonus(
            Guid bonusID,
            UpdateXPBonusOptions updateXPBonusOptions)
        {
            return Request.ExecuteSyncRequest<BonusResponse>(
                Config.EndPointPaths.Bonuses.Update,
                xpService,
                updateXPBonusOptions.BuildFormData(bonusID)
            );
        }

        /// <summary>Update an existing XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/update-bonus" />
        [UsedImplicitly]
        public async Task<BonusResponse> UpdateBonusAsync(
            Guid bonusID,
            UpdateXPBonusOptions updateXPBonusOptions)
        {
            return await Request.ExecuteAsyncRequest<BonusResponse>(
                Config.EndPointPaths.Bonuses.Update,
                xpService,
                updateXPBonusOptions.BuildFormData(bonusID)
            );
        }
    }
    

    [UsedImplicitly]
    public sealed class UpdateXPBonusOptions
    {
        [UsedImplicitly]
        public DateTime? Start { private get; set; }

        [UsedImplicitly]
        public DateTime? End { private get; set; }

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
        public decimal? Modifier { private get; set; }
    
        internal Dictionary<string, string> BuildFormData(Guid bonusID)
        {
            var formData = new Dictionary<string, string>
            {
                { "title", Title },
                { "description", Description },
                { "language", LanguageISO },
                { "bonusID", bonusID.ToString() }
            };
            if (Start.HasValue)
            {
                formData.Add("start", new DateTimeOffset(Start.Value).ToUnixTimeSeconds().ToString());
            }
            if (End.HasValue)
            {
                formData.Add("end", new DateTimeOffset(End.Value).ToUnixTimeSeconds().ToString());
            }

            if(Modifier.HasValue) formData.Add("modifier", Modifier.Value.ToString(CultureInfo.InvariantCulture));
            return formData;
        }
    }
}
