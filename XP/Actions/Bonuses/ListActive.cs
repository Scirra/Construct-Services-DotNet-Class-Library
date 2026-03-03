using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    extension(XPService xpService)
    {
        /// <summary>Retrieve all active XP bonuses</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/list-active" />
        [UsedImplicitly]
        public BonusesResponse ListActiveBonuses(ListActiveBonusesOptions listActiveBonusesOptions = null)
        {              
            return Request.ExecuteSyncRequest<BonusesResponse>(
                Config.EndPointPaths.Bonuses.ListActive,
                xpService,
                null
            );
        }        
        
        /// <summary>Retrieve all active XP bonuses</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/list-active" />
        [UsedImplicitly]
        public async Task<BonusesResponse> ListActiveBonusesAsync(ListActiveBonusesOptions listActiveBonusesOptions = null)
        {                    
            return await Request.ExecuteAsyncRequest<BonusesResponse>(
                Config.EndPointPaths.Bonuses.ListActive,
                xpService,
                null
            );
        }
    }

    [UsedImplicitly]
    public sealed class ListActiveBonusesOptions;
}
