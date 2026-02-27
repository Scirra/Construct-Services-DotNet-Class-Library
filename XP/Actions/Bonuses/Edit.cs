using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

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
        public Language NewLanguage { get; set; }

        [UsedImplicitly]
        public string NewTitle { get; set; }

        [UsedImplicitly]
        public string NewDescription { get; set; }
    }

    private static Dictionary<string, string> BuildFormData(this BonusUpdateOptions updateOptions)
    {
        var formData = new Dictionary<string, string>();

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

        if (updateOptions.NewLanguage != null)
            formData.Add("language", updateOptions.NewLanguage.ISO);

        return formData;
    }

    extension(XPService xpService)
    {
        /// <summary>
        /// Update an existing bonus
        /// </summary>
        [UsedImplicitly]
        public BaseResponse UpdateBonus(
            Guid bonusID,
            BonusUpdateOptions updateOptions)
        {
            return Request.ExecuteSyncRequest<BaseResponse>(
                EditBonusAPIPath,
                xpService,
                updateOptions.BuildFormData()
            );
        }
        /// <summary>
        /// Update an existing bonus
        /// </summary>
        [UsedImplicitly]
        public async Task<BaseResponse> UpdateBonusAsync(
            Guid bonusID,
            BonusUpdateOptions updateOptions)
        {
            return await Request.ExecuteAsyncRequest<BaseResponse>(
                EditBonusAPIPath,
                xpService,
                updateOptions.BuildFormData()
            );
        }
    }
}
