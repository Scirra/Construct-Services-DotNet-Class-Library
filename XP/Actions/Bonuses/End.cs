using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;
public static partial class Bonuses
{
    extension(XPService xpService)
    {
        /// <summary>End a currently active Bonus</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/update-bonus" />
        [UsedImplicitly]
        public BonusResponse EndBonus(
            Guid bonusID)
        {
            var getBonusResponse = xpService.GetBonus(bonusID);
            if (!getBonusResponse.Success)
            {
                return new BonusResponse(getBonusResponse.ErrorMessage);
            }

            var bonus = getBonusResponse.Bonus;
            if (!bonus.IsLive)
            {
                return new BonusResponse
                {
                    Bonus = bonus
                };
            }

            var updateOptions = new UpdateXPBonusOptions
            {
                End = DateTime.UtcNow.AddSeconds(-15)
            };
            return Request.ExecuteSyncRequest<BonusResponse>(
                Config.EndPointPaths.Bonuses.Update,
                xpService,
                updateOptions.BuildFormData(bonusID)
            );
        }
        
        /// <summary>End a currently active Bonus</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/update-bonus" />
        [UsedImplicitly]
        public async Task<BonusResponse> EndBonusBonusAsync(
            Guid bonusID)
        {
            var getBonusResponse = await xpService.GetBonusAsync(bonusID);
            if (!getBonusResponse.Success)
            {
                return new BonusResponse(getBonusResponse.ErrorMessage);
            }

            var bonus = getBonusResponse.Bonus;
            if (!bonus.IsLive)
            {
                return new BonusResponse
                {
                    Bonus = bonus
                };
            }

            var updateOptions = new UpdateXPBonusOptions
            {
                End = DateTime.UtcNow.AddSeconds(-15)
            };
            return await Request.ExecuteAsyncRequest<BonusResponse>(
                Config.EndPointPaths.Bonuses.Update,
                xpService,
                updateOptions.BuildFormData(bonusID)
            );
        }
    }
}
