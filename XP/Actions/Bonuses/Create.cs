using System;
using System.Collections.Generic;
using System.Globalization;
using ConstructServices.Common;
using ConstructServices.XP.Responses;
using JetBrains.Annotations;
using System.Threading.Tasks;

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
                Config.EndPointPaths.Bonuses.Create,
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
                Config.EndPointPaths.Bonuses.Create,
                xpService,
                createXPBonusOptions.BuildFormData()
            );
        }
    }
    
    [UsedImplicitly]
    public sealed class CreateXPBonusOptions(
        DateTime startDate,
        DateTime endDate,
        decimal modifier,
        string title,
        string description,
        string languageISO = null)
    {
        private DateTime Start { get;} = startDate;
        private DateTime End { get; } = endDate;
        private string Title { get;  } = title;
        private string Description { get; } = description;
        private string LanguageISO { get; } = languageISO;
        private decimal Modifier { get; } = modifier;

        internal Dictionary<string, string> BuildFormData()
        {
            var formData = new Dictionary<string, string>
            {
                { "start", new DateTimeOffset(Start).ToUnixTimeSeconds().ToString() },
                { "end", new DateTimeOffset(End).ToUnixTimeSeconds().ToString() },
                { "title", Title },
                { "description", Description },
                { "language", LanguageISO },
                { "modifier", Modifier.ToString(CultureInfo.InvariantCulture) }
            };
            return formData;
        }
    }
}