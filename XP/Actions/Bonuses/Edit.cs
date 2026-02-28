using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ConstructServices.XP.Responses;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    private const string EditBonusAPIPath = "/editbonus.json";

    [UsedImplicitly]
    public sealed class BonusUpdateOptions
    {
        [UsedImplicitly]
        public DateTime? NewStartDate { get; set; }

        [UsedImplicitly]
        public DateTime? NewEndDate { get; set; }

        [UsedImplicitly]
        public decimal? NewModifier { get; set; }

        [UsedImplicitly]
        public string NewLanguageISO { get; set; }

        [UsedImplicitly]
        public string NewTitle { get; set; }

        [UsedImplicitly]
        public string NewDescription { get; set; }
    }

    private static Dictionary<string, string> BuildFormData(this BonusUpdateOptions updateOptions, Guid bonusID)
    {
        var formData = new Dictionary<string, string>();
        
        if (updateOptions.NewLanguageISO != null)
            formData.Add("bonusID", bonusID.ToString());

        if (updateOptions.NewStartDate.HasValue)
            formData.Add("start", new DateTimeOffset(updateOptions.NewStartDate.Value).ToUnixTimeSeconds().ToString());

        if (updateOptions.NewEndDate.HasValue)
            formData.Add("end", new DateTimeOffset(updateOptions.NewEndDate.Value).ToUnixTimeSeconds().ToString());

        if (updateOptions.NewModifier.HasValue)
            formData.Add("modifier", updateOptions.NewModifier.Value.ToString(CultureInfo.InvariantCulture));
            
        if (updateOptions.NewTitle != null)
            formData.Add("title", updateOptions.NewTitle);

        if (updateOptions.NewDescription != null)
            formData.Add("description", updateOptions.NewDescription);

        if (updateOptions.NewLanguageISO != null)
            formData.Add("language", updateOptions.NewLanguageISO);

        return formData;
    }

    extension(XPService xpService)
    {
        /// <summary>
        /// Update an existing bonus
        /// </summary>
        [UsedImplicitly]
        public BonusResponse UpdateBonus(
            Guid bonusID,
            BonusUpdateOptions updateOptions)
        {
            return Request.ExecuteSyncRequest<BonusResponse>(
                EditBonusAPIPath,
                xpService,
                updateOptions.BuildFormData(bonusID)
            );
        }
        /// <summary>
        /// Update an existing bonus
        /// </summary>
        [UsedImplicitly]
        public async Task<BonusResponse> UpdateBonusAsync(
            Guid bonusID,
            BonusUpdateOptions updateOptions)
        {
            return await Request.ExecuteAsyncRequest<BonusResponse>(
                EditBonusAPIPath,
                xpService,
                updateOptions.BuildFormData(bonusID)
            );
        }
    }
}
