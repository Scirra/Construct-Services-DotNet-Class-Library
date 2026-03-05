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
    public sealed class ListBonusesOptions(DateTime from, DateTime to)
    {
        private DateTime Start { get; } = from;
        private DateTime End { get; } = to;

        public ListBonusesOptions(DateTime to) : this(DateTime.UtcNow, to)
        {
        }

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "start", new DateTimeOffset(Start).ToUnixTimeSeconds().ToString() },
                { "end", new DateTimeOffset(End).ToUnixTimeSeconds().ToString() }
            };
            return formData;
        }
    }
}
