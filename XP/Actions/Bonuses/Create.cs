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
        /// <summary>
        /// Creates a new XP Bonus object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/create-bonus" />
        [UsedImplicitly]
        public BonusResponse CreateBonus(CreateXPBonusOptions createXPBonusOptions)
        {
            return Request.ExecuteSyncRequest<BonusResponse>(
                Config.CreateBonusAPIPath,
                xpService,
                createXPBonusOptions.BuildFormData()
            );
        }

        /// <summary>
        /// Creates a new XP Bonus object
        /// </summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/create-bonus" />
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