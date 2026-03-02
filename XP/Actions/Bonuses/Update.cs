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
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/edit-bonus" />
        [UsedImplicitly]
        public BonusResponse UpdateBonus(
            UpdateXPBonusOptions updateXPBonusOptions)
        {
            return Request.ExecuteSyncRequest<BonusResponse>(
                Config.EndPointPaths.Bonuses.Update,
                xpService,
                updateXPBonusOptions.BuildFormData()
            );
        }

        /// <summary>Update an existing XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/edit-bonus" />
        [UsedImplicitly]
        public async Task<BonusResponse> UpdateBonusAsync(
            UpdateXPBonusOptions updateXPBonusOptions)
        {
            return await Request.ExecuteAsyncRequest<BonusResponse>(
                Config.EndPointPaths.Bonuses.Update,
                xpService,
                updateXPBonusOptions.BuildFormData()
            );
        }
    }
    

    [UsedImplicitly]
    public sealed class UpdateXPBonusOptions
    {
        private Guid ID { get; }

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
    
        public UpdateXPBonusOptions(Guid bonusID)
        {
            ID = bonusID;
        }
        public UpdateXPBonusOptions(string strBonusID)
        {
            ID = Guid.Parse(strBonusID);
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
                { "bonusID", ID.ToString() }
            };
            if(Modifier.HasValue) formData.Add("modifier", Modifier.Value.ToString(CultureInfo.InvariantCulture));
            return formData;
        }
    }
}
