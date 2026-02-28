using ConstructServices.Common;
using ConstructServices.XP.Objects;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    extension(XPService xpService)
    {
        [UsedImplicitly]
        public BonusResponse UpdateBonus(
            UpdateXPBonusOptions updateXPBonusOptions)
        {
            return Request.ExecuteSyncRequest<BonusResponse>(
                Config.EditBonusAPIPath,
                xpService,
                updateXPBonusOptions.BuildFormData()
            );
        }

        [UsedImplicitly]
        public async Task<BonusResponse> UpdateBonusAsync(
            UpdateXPBonusOptions updateXPBonusOptions)
        {
            return await Request.ExecuteAsyncRequest<BonusResponse>(
                Config.EditBonusAPIPath,
                xpService,
                updateXPBonusOptions.BuildFormData()
            );
        }
    }
}
