using ConstructServices.Common;
using ConstructServices.XP.Objects;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    private const string EditBonusAPIPath = "/editbonus.json";

    extension(XPService xpService)
    {
        [UsedImplicitly]
        public BonusResponse UpdateBonus(
            UpdateXPBonusOptions updateXPBonusOptions)
        {
            return Request.ExecuteSyncRequest<BonusResponse>(
                EditBonusAPIPath,
                xpService,
                updateXPBonusOptions.BuildFormData()
            );
        }

        [UsedImplicitly]
        public async Task<BonusResponse> UpdateBonusAsync(
            UpdateXPBonusOptions updateXPBonusOptions)
        {
            return await Request.ExecuteAsyncRequest<BonusResponse>(
                EditBonusAPIPath,
                xpService,
                updateXPBonusOptions.BuildFormData()
            );
        }
    }
}
