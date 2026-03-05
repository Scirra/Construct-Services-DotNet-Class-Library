using System;
using System.Collections.Generic;
using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    extension(XPServiceBase xpService)
    {
        /// <summary>Retrieve all XP Bonus objects between date ranges</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/list-bonuses" />
        [UsedImplicitly]
        public BonusesResponse ListBonuses(ListBonusesOptions listBonusesOptions)
        {              
            return Request.ExecuteSyncRequest<BonusesResponse>(
                Config.EndPointPaths.Bonuses.List,
                xpService,
                listBonusesOptions?.BuildFormData()
            );
        }        
        
        /// <summary>Retrieve all XP Bonus objects between date ranges</summary>
        /// <see href="https://www.construct.net/en/game-services/manuals/game-services/xp/api-end-points/bonuses/list-bonuses" />
        [UsedImplicitly]
        public async Task<BonusesResponse> ListBonusesAsync(ListBonusesOptions listBonusesOptions)
        {                    
            return await Request.ExecuteAsyncRequest<BonusesResponse>(
                Config.EndPointPaths.Bonuses.List,
                xpService,
                listBonusesOptions?.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class ListBonusesOptions
    {
        [UsedImplicitly]
        public DateTime? Start { private get; set; }
        
        [UsedImplicitly]
        public DateTime End { private get; set; }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "end", new DateTimeOffset(End).ToUnixTimeSeconds().ToString() }
            };
            if (Start.HasValue)
            {
                formData.Add("start", new DateTimeOffset(Start.Value).ToUnixTimeSeconds().ToString());
            }
            return formData;
        }
    }
}
