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
        /// <summary>Update an existing XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/edit-bonus" />
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

        /// <summary>Update an existing XP Bonus object</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/edit-bonus" />
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
