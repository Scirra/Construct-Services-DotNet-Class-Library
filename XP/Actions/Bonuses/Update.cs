using System;
using System.Collections.Generic;
using System.Globalization;
using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
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
        public DateTime Start { get; set; }

        [UsedImplicitly]
        public DateTime End { get; set; }

        [UsedImplicitly]
        public string Title { get; set; }

        [UsedImplicitly]
        public string Description { get; set; }

        [UsedImplicitly]
        public string LanguageISO { get; set; }
        [UsedImplicitly]
        public decimal? Modifier { get; set; }
    
        internal Dictionary<string, string> BuildFormData(Guid bonusID)
        {
            var formData = new Dictionary<string, string>
            {
                { "start", new DateTimeOffset(Start).ToUnixTimeSeconds().ToString() },
                { "end", new DateTimeOffset(End).ToUnixTimeSeconds().ToString() },
                { "title", Title },
                { "description", Description },
                { "language", LanguageISO },
                { "bonusID", bonusID.ToString() }
            };
            if(Modifier.HasValue) formData.Add("modifier", Modifier.Value.ToString(CultureInfo.InvariantCulture));
            return formData;
        }
    }
}
