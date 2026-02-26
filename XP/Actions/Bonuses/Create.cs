using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace ConstructServices.XP.Actions;

public static partial class Bonuses
{
    private const string CreateBonusAPIPath = "/createbonus.json";
    
    extension(XPService xpService)
    {
        /// <summary>
        /// Create a new XP bonus
        /// </summary>
        /// <param name="start">The start date of the bonus.</param>
        /// <param name="end">The end date of the bonus.</param>
        /// <param name="modifier">The bonus amount (eg 2.5x)</param>
        /// <param name="title">A title for the bonus.</param>
        /// <param name="description">A description for the bonus.</param>
        /// <param name="language">The language that the title and description are written in.  Defaults to your games default language if not specified.</param>
        [UsedImplicitly]
        public BonusResponse Create(
            DateTime start,
            DateTime end,
            decimal modifier,
            string title = null, 
            string description = null, 
            Language language = null)
        {
            var formData = new Dictionary<string, string>
            {
                {"start", new DateTimeOffset(start).ToUnixTimeSeconds().ToString() },
                {"end", new DateTimeOffset(end).ToUnixTimeSeconds().ToString() },
                {"modifier", modifier.ToString(CultureInfo.InvariantCulture) },
                {"title", title ?? string.Empty },
                {"description", description ?? string.Empty },
                {"language", language?.ISO ?? string.Empty }
            };
        
            return Request.ExecuteSyncRequest<BonusResponse>(
                CreateBonusAPIPath,
                xpService,
                formData
            );
        }

        /// <summary>
        /// Create a new XP bonus
        /// </summary>
        /// <param name="start">The start date of the bonus.</param>
        /// <param name="end">The end date of the bonus.</param>
        /// <param name="modifier">The bonus amount (eg 2.5x)</param>
        /// <param name="title">A title for the bonus.</param>
        /// <param name="description">A description for the bonus.</param>
        /// <param name="language">The language that the title and description are written in.  Defaults to your games default language if not specified.</param>
        [UsedImplicitly]
        public async Task<BonusResponse> CreateAsync(
            DateTime start,
            DateTime end,
            decimal modifier,
            string title = null, 
            string description = null, 
            Language language = null)
        {
            var formData = new Dictionary<string, string>
            {
                {"start", new DateTimeOffset(start).ToUnixTimeSeconds().ToString() },
                {"end", new DateTimeOffset(end).ToUnixTimeSeconds().ToString() },
                {"modifier", modifier.ToString(CultureInfo.InvariantCulture) },
                {"title", title ?? string.Empty },
                {"description", description ?? string.Empty },
                {"language", language?.ISO ?? string.Empty }
            };
        
            return await Request.ExecuteAsyncRequest<BonusResponse>(
                CreateBonusAPIPath,
                xpService,
                formData
            );
        }
    }
}