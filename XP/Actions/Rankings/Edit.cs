using ConstructServices.Common;
using ConstructServices.XP.Objects;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Rankings
{        
    private const string EditRankAPIPath = "/editrank.json";

    extension(XPService xpService)
    {
        public RankResponse UpdateRank(
            string strRankID,
            UpdateXPRankOptions updateOptions)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strRankID);
            if (!idValidator.Successfull)
            {
                return new RankResponse(string.Format(idValidator.ErrorMessage, "Rank ID"));
            }
            return xpService.UpdateRank(idValidator.ReturnedObject, updateOptions);
        }

        [UsedImplicitly]
        public RankResponse UpdateRank(
            Guid rankID,
            UpdateXPRankOptions updateOptions)
        {
            return Request.ExecuteSyncRequest<RankResponse>(
                EditRankAPIPath,
                xpService,
                updateOptions.BuildFormData(rankID)
            );
        }

        public async Task<RankResponse> UpdateRankAsync(
            string strRankID,
            UpdateXPRankOptions updateOptions)
        {
            var idValidator = Common.Validations.Guid.IsValidGuid(strRankID);
            if (!idValidator.Successfull)
            {
                return new RankResponse(string.Format(idValidator.ErrorMessage, "Rank ID"));
            }
            return await xpService.UpdateRankAsync(idValidator.ReturnedObject, updateOptions);
        }

        [UsedImplicitly]
        public async Task<RankResponse> UpdateRankAsync(
            Guid rankID,
            UpdateXPRankOptions updateOptions)
        {
            return await Request.ExecuteAsyncRequest<RankResponse>(
                EditRankAPIPath,
                xpService,
                updateOptions.BuildFormData(rankID)
            );
        }
    }
}