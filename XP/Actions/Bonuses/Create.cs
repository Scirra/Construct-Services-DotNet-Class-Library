using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;
using ConstructServices.XP.Objects;

namespace ConstructServices.XP.Actions;
public static partial class Bonuses
{
    extension(XPService xpService)
    {
        [UsedImplicitly]
        public BonusResponse CreateBonus(CreateXPBonusOptions createXPBonusOptions)
        {
            return Request.ExecuteSyncRequest<BonusResponse>(
                Config.CreateBonusAPIPath,
                xpService,
                createXPBonusOptions.BuildFormData()
            );
        }

        [UsedImplicitly]
        public async Task<BonusResponse> CreateBonusAsync(CreateXPBonusOptions createXPBonusOptions)
        {
            return await Request.ExecuteAsyncRequest<BonusResponse>(
                Config.CreateBonusAPIPath,
                xpService,
                createXPBonusOptions.BuildFormData()
            );
        }
    }
}