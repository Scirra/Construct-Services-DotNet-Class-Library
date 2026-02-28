using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Rankings
{        
    private const string EditRankAPIPath = "/editrank.json";

    [UsedImplicitly]
    public sealed class RankUpdateOptions
    {
        [UsedImplicitly]
        public long? NewXP { get; set; }

        [UsedImplicitly]
        public string NewLanguageISO { get; set; }

        [UsedImplicitly]
        public string NewTitle { get; set; }

        [UsedImplicitly]
        public string NewDescription { get; set; }
    }

    private static Dictionary<string, string> BuildFormData(this RankUpdateOptions updateOptions, Guid rankID)
    {            
        var formData = new Dictionary<string, string>
        {
            { "rankID", rankID.ToString() }
        };

        if (updateOptions.NewXP.HasValue)
            formData.Add("xp", updateOptions.NewXP.Value.ToString());

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
        /// Update an existing rank
        /// </summary>
        public RankResponse UpdateRank(
            string strRankID,
            RankUpdateOptions updateOptions)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strRankID);
            if (!idValidator.Successfull)
            {
                return new RankResponse(string.Format(idValidator.ErrorMessage, "Rank ID"));
            }
            return xpService.UpdateRank(idValidator.ReturnedObject, updateOptions);
        }

        /// <summary>
        /// Update an existing rank
        /// </summary>
        [UsedImplicitly]
        public RankResponse UpdateRank(
            Guid rankID,
            RankUpdateOptions updateOptions)
        {
            return Request.ExecuteSyncRequest<RankResponse>(
                EditRankAPIPath,
                xpService,
                updateOptions.BuildFormData(rankID)
            );
        }

        /// <summary>
        /// Update an existing rank
        /// </summary>
        public async Task<RankResponse> UpdateRankAsync(
            string strRankID,
            RankUpdateOptions updateOptions)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strRankID);
            if (!idValidator.Successfull)
            {
                return new RankResponse(string.Format(idValidator.ErrorMessage, "Rank ID"));
            }
            return await xpService.UpdateRankAsync(idValidator.ReturnedObject, updateOptions);
        }

        /// <summary>
        /// Update an existing rank
        /// </summary>
        [UsedImplicitly]
        public async Task<RankResponse> UpdateRankAsync(
            Guid rankID,
            RankUpdateOptions updateOptions)
        {
            return await Request.ExecuteAsyncRequest<RankResponse>(
                EditRankAPIPath,
                xpService,
                updateOptions.BuildFormData(rankID)
            );
        }
    }
}