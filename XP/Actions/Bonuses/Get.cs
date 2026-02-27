using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    private const string GetActiveBonusesAPIPath = "/activebonuses.json";
    private const string GetUpcomingBonusesAPIPath = "/upcomingbonuses.json";

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
        /// Get upcoming bonuses that have not yet started
        /// </summary>
        /// <param name="days">Days to look ahead</param>
        [UsedImplicitly]
        public BonusesResponse GetUpcomingBonuses(int? days = null)
        {                    
            var formData = new Dictionary<string, string>();
            if (days.HasValue)
            {
                formData.Add("days", days.Value.ToString());
            }

            return Request.ExecuteSyncRequest<BonusesResponse>(
                GetUpcomingBonusesAPIPath,
                xpService,
                formData
            );
        }

        /// <summary>
        /// Get upcoming bonuses that have not yet started
        /// </summary>
        /// <param name="days">Days to look ahead</param>
        [UsedImplicitly]
        public async Task<BonusesResponse> GetUpcomingBonusesAsync(int? days = null)
        {                    
            var formData = new Dictionary<string, string>();
            if (days.HasValue)
            {
                formData.Add("days", days.Value.ToString());
            }

            return await Request.ExecuteAsyncRequest<BonusesResponse>(
                GetUpcomingBonusesAPIPath,
                xpService,
                formData
            );
        }

    }
}