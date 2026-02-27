using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    private const string GetActiveBonusesAPIPath = "/activebonuses.json";
    private const string ListBonusesAPIPath = "/listbonuses.json";

    extension(XPService xpService)
    {
        /// <summary>
        /// Get currently active bonuses
        /// </summary>
        [UsedImplicitly]
        public BonusesResponse GetActiveBonuses()
        {            
            return Request.ExecuteSyncRequest<BonusesResponse>(
                GetActiveBonusesAPIPath,
                xpService,
                []
            );
        }

        /// <summary>
        /// Get currently active bonuses
        /// </summary>
        [UsedImplicitly]
        public async Task<BonusesResponse> GetActiveBonusesAsync()
        {            
            return await Request.ExecuteAsyncRequest<BonusesResponse>(
                GetActiveBonusesAPIPath,
                xpService,
                []
            );
        }

        /// <summary>
        /// List bonuses from now until end date
        /// </summary>
        [UsedImplicitly]
        public BonusesResponse GetBonuses(DateTime end)
            => xpService.GetBonuses(DateTime.UtcNow, end);

        /// <summary>
        /// List bonuses between two dates
        /// </summary>
        [UsedImplicitly]
        public BonusesResponse GetBonuses(DateTime start, DateTime end)
        {                    
            var formData = new Dictionary<string, string>
            {
                { "start", new DateTimeOffset(start).ToUnixTimeSeconds().ToString() },
                { "end", new DateTimeOffset(end).ToUnixTimeSeconds().ToString() }
            };

            return Request.ExecuteSyncRequest<BonusesResponse>(
                ListBonusesAPIPath,
                xpService,
                formData
            );
        }        
        
        /// <summary>
        /// List bonuses from now until end date
        /// </summary>
        [UsedImplicitly]
        public async Task<BonusesResponse> GetBonusesAsync(DateTime end)
            => await xpService.GetBonusesAsync(DateTime.UtcNow, end);

        /// <summary>
        /// Get upcoming bonuses that have not yet started
        /// </summary>
        [UsedImplicitly]
        public async Task<BonusesResponse> GetBonusesAsync(DateTime start, DateTime end)
        {                    
            var formData = new Dictionary<string, string>
            {
                { "start", new DateTimeOffset(start).ToUnixTimeSeconds().ToString() },
                { "end", new DateTimeOffset(end).ToUnixTimeSeconds().ToString() }
            };

            return await Request.ExecuteAsyncRequest<BonusesResponse>(
                ListBonusesAPIPath,
                xpService,
                formData
            );
        }

    }
}