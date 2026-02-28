using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    private const string GetActiveBonusesAPIPath = "/activebonuses.json";
    private const string ListBonusesAPIPath = "/listbonuses.json";
    private const string GetBonusAPIPath = "/getbonus.json";

    extension(XPService xpService)
    {
        [UsedImplicitly]
        public BonusResponse GetBonus(string strBonusID)
        {            
            var idValidator = Common.Validations.Guid.IsValidGuid(strBonusID);
            if (!idValidator.Successfull)
            {
                return new BonusResponse(string.Format(idValidator.ErrorMessage, "Bonus ID"));
            }
            return xpService.GetBonus(idValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public BonusResponse GetBonus(Guid bonusID)
        {                   
            var formData = new Dictionary<string, string>
            {
                { "bonusID", bonusID.ToString() }
            };

            return Request.ExecuteSyncRequest<BonusResponse>(
                GetBonusAPIPath,
                xpService,
                formData
            );
        }

        [UsedImplicitly]
        public async Task<BonusResponse> GetBonusAsync(string strBonusID)
        {            
            var idValidator = Common.Validations.Guid.IsValidGuid(strBonusID);
            if (!idValidator.Successfull)
            {
                return new BonusResponse(string.Format(idValidator.ErrorMessage, "Bonus ID"));
            }
            return await xpService.GetBonusAsync(idValidator.ReturnedObject);
        }

        [UsedImplicitly]
        public async Task<BonusResponse> GetBonusAsync(Guid bonusID)
        {             
            var formData = new Dictionary<string, string>
            {
                { "bonusID", bonusID.ToString() }
            };

            return await Request.ExecuteAsyncRequest<BonusResponse>(
                GetBonusAPIPath,
                xpService,
                formData
            );
        }

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